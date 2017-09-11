using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlScript : MonoBehaviour {

   public GameObject[] animationObjects;
   private GameObject _createdObject;
   private GameObject _createdObject2;
   public Button pauseButton, playButton, aButton, bButton, cButton, restartButton, quitButton;
   private int _step, _idleCount, _choiceMade;
   private Animator _animator;

	// Use this for initialization
   void Start () {
      pauseButton.gameObject.SetActive(false);
      playButton.gameObject.SetActive(false);
      aButton.gameObject.SetActive(false);
      bButton.gameObject.SetActive(false);
      cButton.gameObject.SetActive(false);
      restartButton.gameObject.SetActive(false);
      quitButton.gameObject.SetActive(false);
      _step = 0;
      _idleCount = 0;
      _choiceMade = 0;

      _createdObject = Instantiate(animationObjects[_step]);
      _createdObject2 = null;

      _animator = _createdObject.GetComponent<Animator>();
      _animator.SetInteger("step", _step);
      if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Jack &Jane"))
      {
         _animator.Play("Jack&Jane");
      }
   }

   public void Reset()
   {
      Start();
   }

   public void Quit()
   {
      Application.Quit();
   }

   // Update is called once per frame
   void Update () {
		switch (_step)
      {
         //Fist start with Jack and Jane
         case 0:
            //if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Jack&Jane"))
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)
            {
               Destroy(_createdObject);
               _step++;
               _createdObject = Instantiate(animationObjects[_step]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               allowPauseScene();
               _animator.Play("Turtle");
            }
            break;
         case 1:
            //if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Turtle"))
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)
            {
               Destroy(_createdObject);
               _step++;
               _createdObject = Instantiate(animationObjects[_step]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               disallowPauseScene();
               _animator.Play("ZebraIntro");
            }
            break;
         case 2:
            //if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraIntro"))
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)
            {
               Destroy(_createdObject);
               _step++;
               _createdObject = Instantiate(animationObjects[_step]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("ZebraIdle");
               _idleCount++;
               presentChoices();
            }
            break;
         case 3:
            //if ((!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraIdle")) && (!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraSpecial")) && (_idleCount < 2) && (_choiceMade == 0))
            if ((_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)  && (_idleCount < 2) && (_choiceMade == 0))
            {
               Destroy(_createdObject);
               _createdObject = Instantiate(animationObjects[_step]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("ZebraIdle");
               _idleCount++;
            }
            //else if ((!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraIdle")) && (!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraSpecial")) && (_idleCount >= 2) && (_choiceMade == 0))
            else if ((_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999) && (_idleCount >= 2) && (_choiceMade == 0))
            { 
               Destroy(_createdObject);
               _createdObject = Instantiate(animationObjects[_step + 1]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("ZebraSpecial");
               _idleCount = 0;
            }
            else if (_choiceMade != 0)
            {
               removeChoices();
               _step++;
            }
            break;
         case 4:
            //if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraSpecial"))
            //if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)
            //{
               Destroy(_createdObject);
               _createdObject = Instantiate(animationObjects[_step + 1]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("ZebraExit");
               _step++;
            //}
            break;
         case 5:
            //if ((!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraExit")) && (_choiceMade == 1))
            if ((_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999) && (_choiceMade == 1))
            {
               Destroy(_createdObject);
               _createdObject = Instantiate(animationObjects[_step + _choiceMade]);
               _createdObject2 = Instantiate(animationObjects[_step + _choiceMade]);
               _animator = _createdObject2.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("Cheeta");
               _step++;
            }
            //else if ((!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraExit")) && (_choiceMade == 2))
            if ((_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999) && (_choiceMade == 2))
            {
               Destroy(_createdObject);
               _createdObject = Instantiate(animationObjects[_step + _choiceMade]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("Monkey");
               _step++;
            }
            //else if ((!_animator.GetCurrentAnimatorStateInfo(0).IsName("ZebraExit")) && (_choiceMade == 3))
            if ((_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999) && (_choiceMade == 3))
            {
               Destroy(_createdObject);
               _createdObject = Instantiate(animationObjects[_step + _choiceMade]);
               _animator = _createdObject.GetComponent<Animator>();
               _animator.SetInteger("step", _step);
               _animator.Play("Parrot");
               _step++;
            }
            break;
         case 6:
            //if ((!_animator.GetCurrentAnimatorStateInfo(0).IsName("Cheeta")) && (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Monkey")) && (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Parrot")))
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)
            {
               Destroy(_createdObject);
               if (_createdObject2 != null)
                  Destroy(_createdObject2);
               _animator.SetInteger("step", _step);
               restartButton.gameObject.SetActive(true);
               quitButton.gameObject.SetActive(true);
               _step++;
            }
            break;
         default: break;
      }
	}

   public void choiceMade(int choice)
   {
      if (choice < 4 && choice > 0)
         _choiceMade = choice;
      else
         _choiceMade = 1;
      removeChoices();
   }

   public void pauseScene()
   {
      Time.timeScale = 0;
      pauseButton.gameObject.SetActive(false);
      playButton.gameObject.SetActive(true);
   }

   public void resumeScene()
   {
      Time.timeScale = 1;
      playButton.gameObject.SetActive(false); ;
      pauseButton.gameObject.SetActive(true);
   }

   private void allowPauseScene()
   {
      pauseButton.gameObject.SetActive(true);
   }

   private void disallowPauseScene()
   {
      pauseButton.gameObject.SetActive(false);
      playButton.gameObject.SetActive(false);
      Time.timeScale = 1;
   }

   private void presentChoices()
   {
      aButton.gameObject.SetActive(true);
      bButton.gameObject.SetActive(true);
      cButton.gameObject.SetActive(true);
   }

   private void removeChoices()
   {
      aButton.gameObject.SetActive(false);
      bButton.gameObject.SetActive(false);
      cButton.gameObject.SetActive(false);
   }
}
