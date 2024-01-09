namespace _15.Event
{
    class Program
    {
        // 이벤트(Event)

        // 일련의 사건이 발생했다는 사실을 다른 객체에게 전달
        // 델리게이트의 일부 기능을 제한하여 이벤트의 용도로 사용

        // A <-> B 두 객체는 Call, Callback 방식으로 구성
        // + A객체가 모든 객체에게 전파의 목적으로 구성하는 방식? 

        // ex) Player가 데미지 받음(이벤트) -> 모든 객체에게 플레이어가 맞았음을 알려줌
        // -> 필요로 하는 객체가 있을 것(체력바, 사운드, 이펙터, 게임 매니저, ...) -> 그리고 해당 객체는 각자 다른 일을 수행함
        // 이 내용이 이벤트의 컨셉 : 여러 객체들에게 처리를 전달하고 대응하도록 하는 것
        // => 콜백을 여러 대상한테 전달

        // <이벤트 선언>
        // 델리게이트 변수 앞에 event 키워드를 추가하여 이벤트로 선언
        public class Player
        {
            private int hp;

            public event Action OnGetCoin;    // 이벤트 -> 코인을 먹었을 때 발생시킬 이벤트
            public Action OnDamaged;          // 델리게이트 -> 데미지 받았을 때 발생시킬 델리게이트
            public Action OnDied;

            private void Die()
            {
                if (OnDied != null)
                {
                    OnDied();
                }
            }

            public void GetCoin()
            {
                Console.WriteLine("플레이어가 코인을 얻음");

                if (OnGetCoin != null)
                {
                    OnGetCoin();       // 일련의 사건이 발생했을 때 이벤트 발생
                }
            }

            public void GetDamaged()
            {
                Console.WriteLine("플레이어가 데미지를 받음");

                if (OnDamaged != null)
                {
                    OnDamaged();       // 일련의 사건이 발생했을 때 이벤트 발생
                }
            }
        }

        // <이벤트 등록 & 해제>
        // 이벤트에 반응할 객체의 추가할 함수를 += 연산자를 통해 참조 추가
        // 이벤트에 반응할 객체의 제거할 함수를 -= 연산자를 통해 참조 제거
        static void Main5(string[] args)
        {
            Player player = new Player();
            UI ui = new UI();
            SFX sfx = new SFX();
            VFX vfx = new VFX();

            // 이벤트에 반응할 객체의 함수 추가
            player.OnGetCoin += ui.CoinUI;      // 플레이어의 OnGetCoin에 CoinUI 함수 추가
            player.OnGetCoin += sfx.CoinSound;  // 플레이어의 OnGetCoin에 CoinSound 함수 추가
            player.OnGetCoin += vfx.CoinEffect; // 플레이어의 OnGetCoin에 CoinEffect 함수 추가

            player.GetCoin();
            // 플레이어가 코인을 얻는 함수를 실행시키며 이벤트를 발생시키고,
            // OnGetCoin에 참조되어 있던 모든 함수를 실행시킴
            // ui.CoinUI();
            // sfx.CoinSound();
            // vfx.CoinEffect(); => 함수들을 호출시켜야 하는 상황을 이벤트 처리로 한번에 호출 

            // 이후로 언제든지 GetCoin을 실행시키면 모든 함수가 동시에 반응함
            // 또한 만약 추가해야 한다면? 
            // player.OnGetCoin += 추가할 함수 로 쉽게 수정 가능
            // player.OnGetCoin -= sfx.CoinSound;

            // <문제점>
            // 1. 델리게이트 체인 = (대입) 가능
            // player.OnGetCoin = sfx.CoinSound;
            // (=) 대입은 기존의 객체를 전부 사라지게 만드니 꼭 주의해야 할 부분
            // 델리게이트로 이벤트를 구현할 때 문제사항 -> 막아야 하는 부분

            // 2. 이벤트 발생이 외부에서도 가능
            // player.OnGetCoin();
            // 외부에서도 호출 가능 -> 플레이어가 특정 상황이 아닌데도 갑자기 실행될 수도 있음
            // player.OnDied();
            // 이벤트 발생을 외부에서 막을 수 없음

            // 해결 방법은?? 델리게이트 변수 앞에 event 키워드 활용
            // 이벤트와 델리게이트의 차이?
            // 1. 이벤트는 (=) 대입이 불가능, 할당과 제거만 가능
            // 2. 클래스 외부에서 이벤트를 발생시킬 수 없음
        }

        public class UI
        {
            public void CoinUI() { Console.WriteLine("UI에 코인수를 갱신"); }
        }

        public class SFX
        {
            public void CoinSound() { Console.WriteLine("코인을 얻는 소리 재생"); }
        }

        public class VFX
        {
            public void CoinEffect() { Console.WriteLine("코인을 얻는 이펙트 재생"); }
        }


        // <델리게이트 체인과 이벤트의 차이점>
        // 델리게이트 또한 체인을 통하여 이벤트로서 구현이 가능
        // 하지만 델리게이트는 두가지 사항 때문에 이벤트로서 사용하기 적합하지 않음
        // 1. = 대입연산을 통해 기존의 이벤트에 반응할 객체 상황이 초기화 될 수 있음
        // 2. 클래스 외부에서 이벤트를 발생시켜 원하지 않는 상황에서 이벤트 발생 가능
        // event 키워드를 추가할 경우 델리게이트에서 위 두가지 기능을 제한하여 이벤트 전용으로 사용을 유도할 수 있음
        // 즉, event 변수는 델리게이트에서 기능을 제한하여 이벤트 전용의 기능만으로 사용하는 기능

        public class EventSender
        {
            public event Action OnEvent;
            public Action OnDelegate;

            public void DelegateCall()
            {
                if (OnDelegate != null)
                {
                    OnDelegate();
                }
            }
            public void EventCall()
            {
                if (OnEvent != null)
                {
                    OnEvent();
                }
            }

        }

        public class EventListener
        {
            public void ReAction() { }
        }

        void Main2()
        {
            EventSender sender = new EventSender();
            EventListener listener1 = new EventListener();
            EventListener listener2 = new EventListener();
            EventListener listener3 = new EventListener();

            // 델리게이트는 대입연산이 가능하며 이벤트에 반응할 객체들의 상황을 잃을 문제점
            sender.OnDelegate += listener1.ReAction;
            sender.OnDelegate += listener2.ReAction;
            sender.OnDelegate = listener3.ReAction; // 주의! 기존의 이벤트에 반응할 객체들이 사라짐

            // 이벤트는 대입연산이 불가능하며 할당 및 제거만 가능
            sender.OnEvent += listener1.ReAction;
            sender.OnEvent += listener2.ReAction;
            // sender.OnEvent = listener3.ReAction; // error : 이벤트는 (=) 연산자 사용 불가능

            sender.OnDelegate(); // 심지어 외부에서 이벤트를 강제로 실행시킬 수 있음
            // sender.OnEvent(); // 이벤트는 불가능 반드시 특정 함수를 통해 실행시킴
            sender.EventCall();
        }
    }
}
