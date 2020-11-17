using UnityEngine;
using UnityEngine.UI;

//Class Responsible for Vehicle Selection
public class VehicleSelection : MonoBehaviour
{
     /// <summary>
     /// Struct which holds the vehicle info
     /// </summary>
    [System.Serializable]
    public struct VehicleStore 
    {
        public Sprite sprite;
        public bool isVehicleSelected;
    }
    public VehicleStore[] vehicles;


    public Image vehicleImg;

    public int currVehicle =0;

    public void InitVehicleSelection()
    {
        currVehicle = PlayerPrefs.GetInt("CurrentVehicle", 0);
        ChangeVehicle(currVehicle);
        SelectVehicle();
    }

    public void ChangeVehicle(int buttonValue)
    {
        currVehicle = Mathf.Clamp(currVehicle + buttonValue, 0, vehicles.Length - 1);
        vehicleImg.sprite = vehicles[currVehicle].sprite;
    }

    public Sprite GetActivePlayerSkin()
    {
        return vehicleImg.sprite;
    }

    public void SelectVehicle()
    {
        if (!vehicles[currVehicle].isVehicleSelected)
        {
            vehicles[currVehicle].isVehicleSelected = true;
            PlayerPrefs.SetInt("CurrentVehicle", currVehicle);
        }
    }

    public void VehicleSelectionState(bool state)
    {
        gameObject.SetActive(state);
    }

    public void Play()
    {
        gameObject.SetActive(false);
        SelectVehicle();
        GameManager.GM.GameStateManaege(GameManager.GameState.GamePlay);
    }
    
}
