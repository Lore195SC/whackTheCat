
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class MoleManager : MonoBehaviour
    {
        private MoleState state;
        private MainManager MainM;
        public RectTransform Mole;
        public GameObject kk;
        private float timer;
        public float timeGoingUp;
        public float timeGoingDown;
        public float timeOnTop;
        public float timeWait;
        public float speed;
        public Color Color1,Color2 ;
        public bool isChanged = false;
        public float maxPositionY;
        public float minPositionY;
        public Image moleImage;
        public Sprite WhackedMole,NullMole;
        
        private void Start()
        {
            moleImage.GetComponent<Button>().onClick.AddListener(OnWhacked);
            MainM = GameObject.FindObjectOfType<MainManager>();
        }

        public void OnWhacked()
        {
            if (MainManager.Main.state != GameState.Playing)
                return;
            Debug.Log("Mole clicked");
            moleImage.sprite = WhackedMole; 
            state = MoleState.Whacked; 
            
        }

        

        private void Update()
        {
            var p = Mole.localPosition;
            timer += Time.deltaTime;          
            

            switch (state)
                {

                    case MoleState.GoingUp:
                        {
                            if (p.y <= maxPositionY)
                                Mole.localPosition = new Vector3(p.x, p.y + speed, p.z);
                                moleImage.sprite = NullMole;
                                moleImage.color = Color2;
                            if (timer > timeGoingUp)
                            {
                                kk.SetActive(true);
                                timer = 0;
                                state = MoleState.OnTop;
                                
                            }
                        }
                        break;
                    case MoleState.OnTop:
                        if (timer > timeOnTop)
                        {
                            timer = 0;
                            state = MoleState.GoingDow;
                        }
                        break;
                    case MoleState.GoingDow:
                        {
                            if (p.y >= minPositionY)
                                Mole.localPosition = new Vector3(p.x, p.y - speed, p.z);
                            if (timer > timeGoingDown)
                            {
                                timer = 0;
                                state = MoleState.Wait;
                            }
                        }
                        break;
                    case MoleState.Wait:                                   
                    if (timer > timeWait)
                        {
                            timer = 0;
                            state = MoleState.GoingUp;
                        }
                        break;
                    case MoleState.Whacked:
                        {
                            if (p.y >= minPositionY)
                            {
                                Mole.localPosition = new Vector3(p.x, p.y - speed * 2, p.z);
                                blink();

                            }
                            else
                            {
                                timeWait = Random.Range(1, 8);
                                state = MoleState.Wait;
                            }
                        }
                        break;
                }
            
        }

        private void blink()
        {
            if (moleImage.color == Color1)
            {
                moleImage.color = Color2;
}
            else
            {
                moleImage.color = Color1;
            }
        }
    }


}