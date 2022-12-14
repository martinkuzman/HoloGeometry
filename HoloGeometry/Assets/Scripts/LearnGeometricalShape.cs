using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class LearnGeometricalShape : MonoBehaviour
    {
        public AudioClip[] audioClips;
        private Button choosenShape;
        private bool isPlaying = false;
        private AudioSource audioSource;
        
        // Start is called before the first frame update
        void Start()
        {
            hideShapes();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void selectShape(Button button)
        {
            // All button objects are saved in variables
            Button selectShapeButton =  GameObject.Find("SelectShapeButton").GetComponent<Button>();
            Button btnPyramid =  GameObject.Find("btnPyramid").GetComponent<Button>();
            Button btnCube =  GameObject.Find("btnCube").GetComponent<Button>();
            Button btnCylinder =  GameObject.Find("btnCylinder").GetComponent<Button>();
            Button btnSphere =  GameObject.Find("btnSphere").GetComponent<Button>();

            // Color of all buttons is reseted
            Color colors = new Color32(71, 65, 131, 255);
            btnPyramid.GetComponentInChildren<Image>().color = colors;
            btnCube.GetComponentInChildren<Image>().color = colors;
            btnCylinder.GetComponentInChildren<Image>().color = colors;
            btnSphere.GetComponentInChildren<Image>().color = colors;
            
            // Button when pressed changes color to blue ( could be changed to any color in fututre )
            button.GetComponentInChildren<Image>().color = new Color32(0, 0, 255, 255);;

            // Button to select shape is enabled to be used
            selectShapeButton.interactable = true;

            // Shape that was selected is saved in this variable
            // Button object is saved!!!
            choosenShape = button;
            fillThirdScreen();
        }

        public void fillThirdScreen()
        {   
            // This part should be finished when we figure out how we are going to make holograms.
            // Right now I have just changed text of description to tell which shape has been selected.
            // We also need better description, audio description, change color functionality and we need to be able to rotate and zoom hologram
            // But I wasn't sure how we are going to do hologram stuff
            if(choosenShape.name == "btnPyramid")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Pyramid:\nA pyramid is a polyhedron with a polygon base and an apex " +
                    "with straight edges and flat faces. Based on their apex alignment with the center of the base, they can be classified into regular and " +
                    "oblique pyramids. The pyramid you see on your screen right now has a quadrilateral base so it is called a square pyramid.";

                hideShapes();
                GameObject.Find("Pyramid").GetComponent<Renderer>().enabled = true;

                PlayerPrefs.SetString("shape", "Pyramid");
                PlayerPrefs.Save();
            }
            else if(choosenShape.name == "btnCube")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Cube:\nA cube is a 3D shape that has six faces in the shape of a square. " +
                    "Its sides are equal in length and the surrounding squares have an equal surface area.";
                
                hideShapes();
                GameObject.Find("Cube").GetComponent<Renderer>().enabled = true;

                PlayerPrefs.SetString("shape", "Cube");
                PlayerPrefs.Save();
            }
            else if(choosenShape.name == "btnCylinder")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Cylinder:\nA cylinder is a 3D shape that has two circular faces, " +
                    "one at the top, one at the bottom, and one curved surface. A cylinder has a height and a radius. The height of a cylinder is the " +
                    "perpendicular distance between the top and bottom faces.";

                hideShapes();
                GameObject.Find("Cylinder").GetComponent<Renderer>().enabled = true;

                PlayerPrefs.SetString("shape", "Cylinder");
                PlayerPrefs.Save();
            }
            else if(choosenShape.name == "btnSphere")
            {
                GameObject.Find("Description").GetComponentInChildren<Text>().text = "Sphere:\nA sphere is a 3D geometrical object that is round in shape " +
                    "and has all of its points on its surface equidistant from its center.";

                hideShapes();
                GameObject.Find("Sphere").GetComponent<Renderer>().enabled = true;

                PlayerPrefs.SetString("shape", "Sphere");
                PlayerPrefs.Save();
            }
        }
        
        public void hideShapes()
        {
            GameObject.Find("Cylinder").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Sphere").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Cube").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Pyramid").GetComponent<Renderer>().enabled = false;
        }

        public void playAudio()
        {   
            audioSource = gameObject.GetComponent<AudioSource>();

            foreach(AudioClip audioClip in audioClips)
            {
                if(audioClip.name == PlayerPrefs.GetString("shape"))
                {
                    audioSource.clip = audioClip;
                }
            }
            if(isPlaying)
            {
                stopAudio();
            }
            else
            {
                audioSource.Play();
                isPlaying = true;
            }
        }

        public void stopAudio()
        {
            if(isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}