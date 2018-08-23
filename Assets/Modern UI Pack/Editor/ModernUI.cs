using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;//C33

public class ModernUIEditor : EditorWindow {

	private static ModernUIEditor instance = null;

	[MenuItem("Tools/Modern UI Pack/Buttons/Basic")]
	static void CreateBasicButton()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Basic"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Basic Outline")]
	static void CreateBasicOutline()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Basic Outline"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Basic With Image")]
	static void CreateBasicWithImage()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Basic With Image"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Basic Outline With Image")]
	static void CreateBasicOutlineWithImage()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Basic Outline With Image"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Box Outline With Image")]
	static void CreateBoxOutlineWithImage()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Box Outline With Image"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Box With Image")]
	static void CreateBoxWithImage()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Box With Image"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Circle Outline With Image")]
	static void CreateCircleOutlineWithImage()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Circle Outline With Image"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Circle With Image")]
	static void CreateCircleWithImage()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Circle With Image"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Rounded")]
	static void RoundedButton()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Rounded Outline"));
	}

	[MenuItem("Tools/Modern UI Pack/Buttons/Rounded Outline")]
	static void RoundedOutline()
	{
		Instantiate(Resources.Load<GameObject>("Buttons/Rounded Outline"));
	}

	[MenuItem("Tools/Modern UI Pack/Notifications/Fading Notification")]
	static void FadingNotification()
	{
		Instantiate(Resources.Load<GameObject>("Notifications/Fading Notification"));
	}

	[MenuItem("Tools/Modern UI Pack/Notifications/Popup Notification")]
	static void PopupNotification()
	{
		Instantiate(Resources.Load<GameObject>("Notifications/Popup Notification"));
	}

	[MenuItem("Tools/Modern UI Pack/Notifications/Slippery Notification")]
	static void SlipperyNotification()
	{
		Instantiate(Resources.Load<GameObject>("Notifications/Slippery Notification"));
	}

	[MenuItem("Tools/Modern UI Pack/Notifications/Slipping Notification")]
	static void SlippingNotification()
	{
		Instantiate(Resources.Load<GameObject>("Notifications/Slipping Notification"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Radial PB Bold")]
	static void RadialPBBold()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Radial PB Bold"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Radial PB Filled H")]
	static void RadialPBFilledH()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Radial PB Filled H"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Radial PB Filled V")]
	static void RadialPBFilledV()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Radial PB Filled V"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Radial PB Light")]
	static void RadialPBLight()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Radial PB Light"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Radial PB Regular")]
	static void RadialPBRegular()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Radial PB Regular"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Radial PB Thin")]
	static void RadialPBThin()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Radial PB Thin"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars/Standard PB")]
	static void StandardPB()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars/Standard PB"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars (Loop)/Circle Glass")]
	static void CircleGlass()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars (Loop)/Circle Glass"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars (Loop)/Circle Pie")]
	static void CirclePie()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars (Loop)/Circle Pie"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars (Loop)/Circle Run")]
	static void CircleRun()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars (Loop)/Circle Run"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars (Loop)/Circle Trapez")]
	static void CircleTrapez()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars (Loop)/Circle Trapez"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars (Loop)/Standard Fastly")]
	static void StandardFastly()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars (Loop)/Standard Fastly"));
	}

	[MenuItem("Tools/Modern UI Pack/Progress Bars (Loop)/Standard Run")]
	static void StandardRun()
	{
		Instantiate(Resources.Load<GameObject>("Progress Bars (Loop)/Standard Run"));
	}

	[MenuItem("Tools/Modern UI Pack/Sliders/Gradient")]
	static void GradientSlider()
	{
		Instantiate(Resources.Load<GameObject>("Sliders/Gradient"));
	}

	[MenuItem("Tools/Modern UI Pack/Sliders/Outline")]
	static void OutlineSlider()
	{
		Instantiate(Resources.Load<GameObject>("Sliders/Outline"));
	}

	[MenuItem("Tools/Modern UI Pack/Sliders/Standard")]
	static void StandardSlider()
	{
		Instantiate(Resources.Load<GameObject>("Sliders/Standard"));
	}

	[MenuItem("Tools/Modern UI Pack/Switches/Outline")]
	static void OutlineSwitch()
	{
		Instantiate(Resources.Load<GameObject>("Switches/Outline"));
	}

	[MenuItem("Tools/Modern UI Pack/Switches/Standard")]
	static void StandardSwitch()
	{
		Instantiate(Resources.Load<GameObject>("Switches/Standard"));
	}

	[MenuItem("Tools/Modern UI Pack/Toggles/Standard (Bold)")]
	static void StandardToggleBold()
	{
		Instantiate(Resources.Load<GameObject>("Toggles/Standard Toggle (Bold)"));
	}

	[MenuItem("Tools/Modern UI Pack/Toggles/Standard (Light)")]
	static void StandardToggleLight()
	{
		Instantiate(Resources.Load<GameObject>("Toggles/Standard Toggle (Light)"));
	}

	[MenuItem("Tools/Modern UI Pack/Toggles/Standard (Regular)")]
	static void StandardToggleRegular()
	{
		Instantiate(Resources.Load<GameObject>("Toggles/Standard Toggle (Regular)"));
	}

	[MenuItem("Tools/Modern UI Pack/Tool Tips/Fading")]
	static void FadingToolTip()
	{
		Instantiate(Resources.Load<GameObject>("Tool Tips/Fading Tool Tip"));
	}

	[MenuItem("Tools/Modern UI Pack/Tool Tips/Scaling")]
	static void ScalingToolTip()
	{
		Instantiate(Resources.Load<GameObject>("Tool Tips/Scaling Tool Tip"));
	}

	[MenuItem("Tools/Modern UI Pack/Dropdowns/Standard")]
	static void StandardDropdown()
	{
		Instantiate(Resources.Load<GameObject>("Dropdowns/Standard Dropdown"));
	}

	[MenuItem("Tools/Modern UI Pack/Dropdowns/Outline")]
	static void StandardDropdownOutline()
	{
		Instantiate(Resources.Load<GameObject>("Dropdowns/Outline Dropdown"));
	}

	[MenuItem("Tools/Modern UI Pack/Input Fields/Standard")]
	static void StandardInputField()
	{
		Instantiate(Resources.Load<GameObject>("Input Fields/Standard Input Field"));
	}

    [MenuItem("Tools/Modern UI Pack/Sliders/Radial Standard")]
    static void StandardRadialSlider()
    {
        Instantiate(Resources.Load<GameObject>("Sliders/Radial Standard"));
    }

    [MenuItem("Tools/Modern UI Pack/Sliders/Radial Gradient")]
    static void GradientRadialSlider()
    {
        Instantiate(Resources.Load<GameObject>("Sliders/Radial Gradient"));
    }

    [MenuItem("Tools/Modern UI Pack/Modal Windows/Style 1/Only Exit Button")]
    static void OEBModal()
    {
        Instantiate(Resources.Load<GameObject>("Modal Windows/Style 1/Standard"));
    }

    [MenuItem("Tools/Modern UI Pack/Modal Windows/Style 1/With Buttons")]
    static void WBModal()
    {
        Instantiate(Resources.Load<GameObject>("Modal Windows/Style 1/With Buttons"));
    }

    [MenuItem("Tools/Modern UI Pack/Modal Windows/Style 1/With Tabs")]
    static void WTabModal()
    {
        Instantiate(Resources.Load<GameObject>("Modal Windows/Style 1/With Tabs"));
    }

    [MenuItem("Tools/Modern UI Pack/Modal Windows/Style 1/Auto-Resizing")]
    static void ATRModal()
    {
        Instantiate(Resources.Load<GameObject>("Modal Windows/Style 1/Auto-Resizing"));
    }

    [MenuItem("Tools/Modern UI Pack/Modal Windows/Style 2/Standard")]
    static void S2TSModal()
    {
        Instantiate(Resources.Load<GameObject>("Modal Windows/Style 2/Standard"));
    }

    [MenuItem("Tools/Modern UI Pack/Modal Windows/Style 2/With Tabs")]
    static void ST2TModal()
    {
        Instantiate(Resources.Load<GameObject>("Modal Windows/Style 2/With Tabs"));
    }

    [MenuItem("Tools/Modern UI Pack/Buttons/Rounded Outline With Image")]
    static void ROWIButton()
    {
        Instantiate(Resources.Load<GameObject>("Buttons/Rounded Outline With Image"));
    }

    [MenuItem("Tools/Modern UI Pack/Buttons/Rounded With Image")]
    static void RWIButton()
    {
        Instantiate(Resources.Load<GameObject>("Buttons/Rounded With Image"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Hamburger to Exit")]
    static void AIHTE()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Hamburger to Exit"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Heart Pop")]
    static void AIHP()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Heart Pop"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Message Bubbles")]
    static void AIMB()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Message Bubbles"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Switch")]
    static void AISW()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Switch"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Yes to No")]
    static void AIYTN()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Yes to No"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Lock")]
    static void AILOCK()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Lock"));
    }

    [MenuItem("Tools/Modern UI Pack/Animated Icons/Sand Clock")]
    static void AISAND()
    {
        Instantiate(Resources.Load<GameObject>("Animated Icons/Sand Clock"));
    }

    public static void OnCustomWindow()
	{
		EditorWindow.GetWindow(typeof(ModernUIEditor));
	}
}
