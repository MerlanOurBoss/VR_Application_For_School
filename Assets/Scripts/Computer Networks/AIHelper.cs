using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class AIHelper : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Текстовое поле для отображения сообщений
    public IPAddressGame game; // Ссылка на скрипт IPAddressGame
    public AudioSource audioSource;
    public int connectedDevices = 0;
    public int currentStep = 1; // Текущий шаг
    private bool isWaitingForInput = false; // Ожидание ввода игрока

    // Аудиоклипы для каждого текста
    public AudioClip[] step1AudioClips;
    public AudioClip[] step2AudioClips;
    public AudioClip[] step3AudioClips;
    public AudioClip[] step4AudioClips;
    public AudioClip[] step5AudioClips;

    public AudioClip[][] errorAudioClips;
    public AudioClip[][] successAudioClips;
    public AudioClip[] finalMessageAudioClip;

    // Тексты для каждого шага
    private string[][] steps = new string[][]
    {
        new string[]
        {
            "Сәлем, досым! Қош келдің, желілік курсқа!",
            "Сәлеметсің бе! Желі сабағына хош келдің!",
            "Сәлем, дос! Желі туралы үйренуге дайынсың ба?",
            "Қош келдің, желілік курсқа!"
        },
        new string[]
        {
            "Бастайық! Үстелдегі кабелді алып, сырттан келіп тұрған интернетке қос.",
            "Жұмысты бастайық! кабелді алып, сыртқы интернетке жалға.",
            "Кеттік! Үстелден кабелді алып, интернет көзіне қос.",
            "Ал, іске кірісейік! Кабелді дұрыс жерге жалға.",
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
            "Дұрыс емес! Кабелді тікелей жалғау керек.",
            "Қате жалғадың! Мұнда тек тура қосу қажет.",
            "Қате кетті! Кабелді тікелей жалға.",
            "Дұрыс емес! Бұл жерге басқаша жалғау қажет."
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
        "Мерзім аяқталды. Қосылу сәтті өтті, тамаша",
        "Уақыт аяқталды. Барлық компьютерлер жалғанды, керемет",
        "Уақыт аяқталды. Компьютерлер жалғаңды, жарайсың",
        "Уақыт бітті. Компьютерлер қосылды, жарайсың",
        "Уақыт өтті. Барлық жүйелер байланыстырылды, өте жақсы"
    };
    void Start()
    {
        DisplayText();

        // Инициализация массива массивов
        errorAudioClips = new AudioClip[3][];

        // Загрузка аудио для первого массива
        errorAudioClips[0] = new AudioClip[]
        {
            LoadAudioClip("Қате! Бұл жерге тікелей қосу қажет"),
            LoadAudioClip("Дұрыс емес! Кабелді тікелей жалғау керек"),
            LoadAudioClip("Қате жалғадың! Мұнда тек тура қосу қажет"),
            LoadAudioClip("Қате кетті! Кабелді тікелей жалға"),
            LoadAudioClip("Дұрыс емес! Бұл жерге басқаша жалғау қажет")
        };

        // Загрузка аудио для второго массива
        errorAudioClips[1] = new AudioClip[]
        {
            LoadAudioClip("Қате! Бұл жерде тікелей қосылу керек"),
            LoadAudioClip("Дұрыс емес! Кабелді тура жалға"),
            LoadAudioClip("Қате кетті! Оны тікелей қосу қажет"),
            LoadAudioClip("Қате жалғадың! Тікелей жалғау керек"),
            LoadAudioClip("Дұрыс емес! Басқа тәсілмен қос")
        };

        // Загрузка аудио для третьего массива
        errorAudioClips[2] = new AudioClip[]
        {
            LoadAudioClip("Қате! Бұл жерде тікелей жалғау керек"),
            LoadAudioClip("Дұрыс емес! Қосылымды дұрыста"),
            LoadAudioClip("Қате кетті! Кабелді тікелей жалғау қажет"),
            LoadAudioClip("Қате жалғадың! Дұрыстап қайта жалға"),
            LoadAudioClip("Дұрыс емес! Қосылымды қайта тексер")
        };

        // Инициализация массива массивов
        successAudioClips = new AudioClip[3][];

        // Загрузка аудио для первого массива
        successAudioClips[0] = new AudioClip[]
        {
            LoadAudioClip("Дұрыс қостың!"),
            LoadAudioClip("Жарайсың! Дұрыс жалғадың"),
            LoadAudioClip("Өте жақсы! Барлығы дұрыс"),
            LoadAudioClip("Дұрыс жалғадың, жалғастырайық!"),
            LoadAudioClip("Тамаша! Барлығы дұрыс жалғанды")
        };

        // Загрузка аудио для второго массива
        successAudioClips[1] = new AudioClip[]
        {
            LoadAudioClip("Дұрыс жалғадың"),
            LoadAudioClip("Жарайсың! Барлығы дұрыс"),
            LoadAudioClip("Тамаша! Қосылым дұрыс жасалды"),
            LoadAudioClip("Өте жақсы! Дұрыс қосылған"),
            LoadAudioClip("Дұрыс! Келесі қадамға өтейік")
        };

        // Загрузка аудио для третьего массива
        successAudioClips[2] = new AudioClip[]
        {
            LoadAudioClip("Дұрыс! Қалған компьютерлерді жалғауға кіріс"),
            LoadAudioClip("Жарайсың! Қазір қалған компьютерлерді жалғайық"),
            LoadAudioClip("Тамаша! Келесі компьютерлерді қоса бер"),
            LoadAudioClip("Дұрыс! Енді қалған құрылғыларды жалға"),
            LoadAudioClip("Өте жақсы! Енді қалғандарын жалғауға көшейік")
        };
    }

    private AudioClip LoadAudioClip(string clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>(clipName);
        if (clip != null)
        {
            Debug.Log($"Аудиофайл '{clipName}' не найден в папке Resources!");
        }
        return clip;
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
        int randomIndex = Random.Range(0, finalMessages.Length);
        string finalMessage = finalMessages[randomIndex];
        //finalMessage = finalMessage.Replace("(сан)", connectedDevices.ToString());
        textDisplay.text = finalMessage;
        PlayFinalAudio(randomIndex);
    }

    // Отображение текста для текущего шага
    void DisplayText()
    {
        if (currentStep <= steps.Length)
        {
            string[] currentTexts = steps[currentStep - 1];
            int randomIndex = Random.Range(0, currentTexts.Length);
            string randomText = currentTexts[randomIndex];
            textDisplay.text = randomText;

            PlayAudioForCurrentStep(randomIndex);
        }
    }

    // Переход к следующему шагу
    public void NextStep()
    {
        currentStep++;
        DisplayText();
    }

    // Воспроизведение аудио для текущего шага
    void PlayAudioForCurrentStep(int index)
    {
        AudioClip[] audioClips = GetAudioClipsForCurrentStep();
        if (audioClips != null && index < audioClips.Length && audioClips[index] != null)
        {
            audioSource.Stop(); // Останавливаем текущее аудио
            audioSource.clip = audioClips[index]; // Устанавливаем новый аудиоклип
            audioSource.Play(); // Воспроизводим аудио
        }
    }

    AudioClip[] GetAudioClipsForCurrentStep()
    {
        switch (currentStep)
        {
            case 1: return step1AudioClips;
            case 2: return step2AudioClips;
            case 3: return step3AudioClips;
            case 4: return step4AudioClips;
            case 5: return step5AudioClips;
            default: return null;
        }
    }

    void PlayErrorAudio(int n, int index)
    {
        if (errorAudioClips.Length > 0)
        {
            audioSource.Stop();
            AudioClip[] errorAudioClip = errorAudioClips[n];
            audioSource.clip = errorAudioClip[index];
            audioSource.Play();
        }
    }

    void PlaySuccessAudio(int n, int index)
    {
        if (successAudioClips.Length > 0)
        {
            audioSource.Stop();
            AudioClip[] successAudioClip = successAudioClips[n];
            audioSource.clip = successAudioClip[index];
            audioSource.Play();
        }
    }

    void PlayFinalAudio(int index)
    {
        if (finalMessageAudioClip != null)
        {
            audioSource.Stop();
            audioSource.clip = finalMessageAudioClip[index];
            audioSource.Play();
        }
    }

    // Обработка правильного действия
    public void OnCorrectAction()
    {
        string[] successTexts = successMessages[currentStep - 3];
        int randomIndex = Random.Range(0, successTexts.Length);
        string randomText = successTexts[randomIndex];
        textDisplay.text = randomText;

        PlaySuccessAudio(currentStep - 3, randomIndex);
        StartCoroutine(WaitAndNextStep());
    }

    // Обработка неправильного действия
    public void OnIncorrectAction()
    {
        string[] errorTexts = errorMessages[currentStep - 3];
        int randomIndex = Random.Range(0, errorTexts.Length);
        string randomText = errorTexts[randomIndex];
        textDisplay.text = randomText;

        PlayErrorAudio(currentStep - 3, randomIndex);
    }

    // Ожидание и переход к следующему шагу
    IEnumerator WaitAndNextStep()
    {
        yield return new WaitForSeconds(5);
        NextStep();
    }
}