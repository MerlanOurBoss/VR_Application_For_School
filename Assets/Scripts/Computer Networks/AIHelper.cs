using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIHelper : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Текстовое поле для отображения сообщений
    public IPAddressGame game; // Ссылка на скрипт IPAddressGame

    public int connectedDevices = 0;
    public int currentStep = 1; // Текущий шаг
    private bool isWaitingForInput = false; // Ожидание ввода игрока

    // Тексты для каждого шага
    private string[][] steps = new string[][]
    {
        new string[]
        {
            "Сәлем, досым! Қош келдің, желілік курсқа!",
            "Сәлеметсің бе! Желі сабағына хош келдің!",
            "Сәлем, дос! Желі туралы үйренуге дайынсың ба?",
            "Қош келдің! Сабақты бастау үшін үстелдегі батырманы бас."
        },
        new string[]
        {
            "Бастайық! Үстелдегі RJ-45 кабелін алып, сырттан келіп тұрған интернетке қос.",
            "Жұмысты бастайық! RJ-45 кабелін алып, сыртқы интернетке жалға.",
            "Кеттік! Үстелден RJ-45 кабелін алып, интернет көзіне қос.",
            "Ал, іске кірісейік! RJ-45 кабелін дұрыс жерге жалға.",
            "Ал, бастайық! Кабелді интернет желісіне жалға."
        },
        new string[]
        {
            "Жарайсың! Енді кабелдің екінші жағын роутерге дұрыс жалға.",
            "Керемет! Енді оны роутерге дұрыс қосу керек.",
            "Дұрыс! Енді оны маршрутизаторға дұрыс жалға.",
            "Тамаша! Кабелдің келесі ұшын роутерге қос.",
            "Өте жақсы! Енді оны маршрутизаторға дұрыс жалға."
        },
        new string[]
        {
            "Келесі қадам – роутерді коммутаторға қосу.",
            "Желі жалғауды жалғастырайық – енді роутерді коммутаторға қос.",
            "Келесі тапсырма: маршрутизаторды коммутаторға жалғау.",
            "Тамаша! Енді роутерді коммутаторға дұрыс жалғау қажет.",
            "Жақсы! Келесі қадам – маршрутизаторды коммутаторға қосу."
        },
        new string[]
        {
            "Өте жақсы! Енді ескі компьютерлерді коммутаторға жалғау қажет. Сол қолында IP адресті тап.",
            "Жарадың! Келесі қадам – компьютерлерді коммутаторға қосу. Алдымен IP адресті анықта.",
            "Жақсы жұмыс! Компьютерлерді коммутаторға дұрыс жалға. Алдымен IP адресті тап.",
            "Тамаша! Компьютерлерді дұрыс жалғап, IP адресті тексер.",
            "Өте жақсы! Қалған компьютерлерді коммутаторға қос."
        }
    };

    // Сообщения об ошибках
    private string[][] errorMessages = new string[][]
    {
        new string[]
        {
            "Қате! Бұл жерге тікелей қосу қажет.",
            "Дұрыс емес! Кабелді тура жалға.",
            "Қате кетті! Оны тікелей қосу қажет.",
            "Қате жалғадың! Тікелей жалғау керек.",
            "Дұрыс емес! Басқа тәсілмен қос."
        },
        new string[]
        {
            "Қате! Бұл жерде тікелей қосылу керек.",
            "Дұрыс емес! Кабелді тура жалға.",
            "Қате кетті! Оны тікелей қосу қажет.",
            "Қате жалғадың! Тікелей жалғау керек.",
            "Дұрыс емес! Басқа тәсілмен қос."
        },
        new string[]
        {
            "Қате! Бұл жерде тікелей жалғау керек.",
            "Дұрыс емес! Қосылымды дұрыста.",
            "Қате кетті! Кабелді тікелей жалғау қажет.",
            "Қате жалғадың! Дұрыстап қайта жалға.",
            "Дұрыс емес! Қосылымды қайта тексер."
        }
    };

    // Сообщения об успехе
    private string[][] successMessages = new string[][]
    {
        new string[]
        {
            "Дұрыс қостың!",
            "Жарайсың! Дұрыс жалғадың.",
            "Өте жақсы! Барлығы дұрыс.",
            "Дұрыс жалғадың, жалғастырайық!",
            "Тамаша! Барлығы дұрыс жалғанды."
        },
        new string[]
        {
            "Дұрыс жалғадың!",
            "Жарайсың! Барлығы дұрыс.",
            "Тамаша! Қосылым дұрыс жасалды.",
            "Өте жақсы! Дұрыс қосылған.",
            "Дұрыс! Келесі қадамға өтейік."
        },
        new string[]
        {
            "Дұрыс! Қалған компьютерлерді жалғауға кіріс.",
            "Жарайсың! Қазір қалған компьютерлерді жалғайық.",
            "Тамаша! Келесі компьютерлерді қоса бер.",
            "Дұрыс! Енді қалған құрылғыларды жалға.",
            "Өте жақсы! Енді қалғандарын жалғауға көшейік."
        }
    };

    private string[] finalMessages = new string[]
    {
        "Уақыт аяқталды. Сен (сан) компьютерді жалғадың, жарайсың!",
        "Керемет! Сен (сан) құрылғыны жалғап үлгердің.",
        "Жарайсың! Барлығы (сан) компьютер жалғанды.",
        "Өте жақсы! Сен (сан) құрылғыны дұрыс жалғап шықтың.",
        "Тамаша! Сен (сан) компьютерді қосып үлгердің."
    };
    void Start()
    {
        DisplayText();
    }

    void Update()
    {
        connectedDevices = game.countComputer;
        if (currentStep == 6)
        {
            currentStep = 5;
        }
        if (game.isPushedButton)
        {
            if (game.remainingTime <= 0 && currentStep < 6)
            {
                currentStep = 6;
                ShowFinalMessage();
                game.isPushedButton = false;
            }
        }
    }

    void ShowFinalMessage()
    {
        string finalMessage = finalMessages[Random.Range(0, finalMessages.Length)];
        finalMessage = finalMessage.Replace("(сан)", connectedDevices.ToString());
        textDisplay.text = finalMessage;
    }

    // Отображение текста для текущего шага
    void DisplayText()
    {
        if (currentStep <= steps.Length)
        {
            string[] currentTexts = steps[currentStep - 1];
            string randomText = currentTexts[Random.Range(0, currentTexts.Length)];
            textDisplay.text = randomText;
        }
    }

    // Переход к следующему шагу
    public void NextStep()
    {
        currentStep++;
        DisplayText();
    }

    // Обработка правильного действия
    public void OnCorrectAction()
    {
        string[] successTexts = successMessages[currentStep - 3];
        string randomText = successTexts[Random.Range(0, successTexts.Length)];
        textDisplay.text = randomText;
        StartCoroutine(WaitAndNextStep());
    }

    // Обработка неправильного действия
    public void OnIncorrectAction()
    {
        string[] errorTexts = errorMessages[currentStep - 3];
        string randomText = errorTexts[Random.Range(0, errorTexts.Length)];
        textDisplay.text = randomText;
    }

    // Ожидание и переход к следующему шагу
    IEnumerator WaitAndNextStep()
    {
        yield return new WaitForSeconds(5);
        NextStep();
    }
}