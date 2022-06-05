public interface ObjectControl
{
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    public void OnPointerEnter();


    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    public void OnPointerExit();


    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen is touched
    public void OnPointerClick();

}
