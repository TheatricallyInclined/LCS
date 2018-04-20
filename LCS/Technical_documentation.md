Lighting Controlled Simply
==========================
**This is a C# project build in Visual Studio, it's development will require Windows Platform and Visual Studio**
**This documentation only provides information about how this software is build along with its code documentation. For details about how to use this software, please consult non-technical user manual**
LCS or Lighting Controlled Simply is a C# desktop based Windows application designed to be an easy to use replacement for two scene preset boards. We are utilizing the open source USB to DMX converter from Enttec to help minimize cost and simplify user hardware complexity. We are looking to deliver all the simplicity and function of a physical board while also having extra tools commonly found in high end boards in order to help the user.
Download or get more information about our software from our website: http://www.acsu.buffalo.edu/~ryang5/

Hardware Needed
----------
•	A DMX (Digital Multiplex 512) based light (A light that can be controlled through DMX512)
More detailed explanation about DMX512 can be found here: https://en.wikipedia.org/wiki/DMX512
•	Enttec USB to DMX converter (which can be found here: https://www.enttec.com/us/products/controls/dmx-usb/open-dmx-usb/)
•	5-pin 	(male) to 3-pin (female) DMX adapter (if necessary for your light)	


Software Needed
----------
•	Enttec USB to DMX Driver (which can be found here: https://www.enttec.com/us/products/controls/dmx-usb/open-dmx-usb/)
•	LCS software (download source code from our GitHub: https://github.com/TheatricallyInclined/LCS)


Features
--------
•	Live computer control of DMX light
•	Have instance and timed transitions between 2 scenes
•	Ability to control any type of DMX functionality including but not limited to Color (RGBCMY), Color Temperature, Intensity, Pan, Tilt, Gobo Selection, Gobo Rotation, FX, FX Speed, etc.

Add on Features
---------------
•	Control multiple types of DMX Lights at once
•	Ability to Create timed Show files and a cue list
•	Ability to create light groups of similar but different addressed fixtures
•	Sound activated mode (Control light through external sound from the environment)

Installation
------------
•	Properly connect the DMX light and the Enttec Converter to your devices.
•	Download our software (zip file) from GitHub, unzip the file. Open the project solution file (LCS\LCS.sln) found in the LCS folder with Visual Studio.
Alternatively, one can clone the project directly from GitHub: https://github.com/TheatricallyInclined/LCS.git with Visual Studio

-------------------------------------------------------------------Code Documentation---------------------------------------------------------------------
Project Directory Tree:
|--project_home_directory
  |--.vs                                  Visual Studio auto-generated directory
  |--LCS              
    |--LCS                                 Source code located inside
      |--bin                               Location of debug and release version of executable file
      |--Resource                          All images are stored in this Directory
      |--Component.cs                      C# source code, more details can be in class explanation below
      |--FixtureNameLabel.cs
      |--InputForm.cs
      |--InputForm.Designer.cs
      |--MainForm.cs
      |--MainForm.Designer.cs
      |--OpenDMX.cs
      |--Program.cs
      |--Service.cs
    |--LCS.exe                             Executable file for non-technical users
    |--LCS.sln                             Visual Studio solution file
  |--Minutes                               Meeting Notes
  |--README.md                             README file

Classes:
  ~/LCS/LCS/Program.cs
  --------------------
  This class is the main entry point of the application

  Methods:
  --------
  static void Main()
    The main method of the application. The program starts here.

  ------------------------------------------------------------------------------

  ~/LCS/LCS/Service.cs
  --------------------
  Service class, controls the logic of this application
  This class provides almost all logics that is needed in this application

  Methods
  -------
  public Service()
    parameters: N/A
    return: N/A

    Constructor method of this class, starts the application

  private void startApp()
    parameters: N/A
    return: N/A

    This method starts the application. It is only called in constructor method of this class

  public void startMain()
    parameters: N/A
    return: N/A

    This method hides the input form, opens the main form and initializes values for main form
    This method is called when the user finished entering input data in input form and all input data is valid.

  private void control()
    parameters: N/A
    return: N/A

    This method controls the light by periodically invoking a method with a timer
    This method will only be called when mainform first pops out

  public bool setChannels(String inputChannels)
    parameters:
      String inputChannels: String representation of total numbers of input channels(get from input form)
    return:
      true: if the string representation of input channel is a valid number
      false: if the input channel is not a valid number

      Check if the input string is a valid numeric value within the range of 0 and max channels
      convert input to int and set the numOfChannels as this input if the input is valid and return true,
      otherwise return false
      This method is called when input form is about to be hidden, and mainform is about to pop out

  public bool setAddress(String inputAddress)
    parameters:
      String inputAddress: String representation of total numbers of input channels(get from input form)
    return:
      true: if the string representation of input channel is a valid number
      false: if the input address is not a valid number

      Check if the input string is a valid start address
      convert input to int and set the startAddress as this input if the input is valid and return true,
      otherwise return false
      This method is called when input form is about to be hidden, and mainform is about to pop out

  public bool setName(String name)
    parameters:
      String name: String representation of the name of this DMX light(get from input form)
    return:
      true: if the string representation of the name is not empty
      false: if the input name is empty

      Check if the input string is a valid  name
      set the fixtureName as this input if the input is valid and return true,
      otherwise return false
      This method is called when input form is about to be hidden, and mainform is about to pop out

  public bool setTransitionTime(String time)
    parameters:
      String name: String representation of the transition time(get from transition time input box in main form)
    return:
      true: if the string representation of the input time is a valid number
      false: if the input time is not valid

      Check if the input string is a valid time
      convert input to int and set the transitionTime as this input if the input is valid and return true,
      otherwise return false
      This method is called whenever user changes value in transition time input box

  public System.Drawing.Size mainFormSize()
    parameters: N/A
    return: System.Drawing.Size
      Size instance which contains height and width of the mainform

    This method calculates the main form size by number of channels that user input
    This method is called when input form is about to be hidden and mainform is about to pop out

  public int scenePanelWidth()
    parameters: N/A
    return: int
      width of the scene panel

    This method calculates scene panel width according to number of channels

  public void setSceneValue(string[,] data)
    parameters:
      string[,] data: two dimensional arrays which holds data of both current and next scenes
    return: N/A

    this method sets both currentSceneValue and nextSceneValue arrays using the values in data array
    will only be called when needed

  public void liveControl(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    This method will control the light lively with current scene values
    This method should be called every 100ms when its not in transition mode in order to get live control of the light

  public void transitionControl(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    This method will control the light transition between current scene and next scene
    This method should be called when it's in transition mode with the transition time inputted by the user

  public void nextPhrase()
    parameters: N/A
    return: N/A

    This method updates current phrase of the transition to next phrase
    should be called in transitionControl() method

  public void calculateTransition()
    parameters: N/A
    return: N/A

    This method calculates and updates the data that uses for transition mode
    should be called when prior transition begin

  *The rest methods in this class are some getter and setter methods*

  ------------------------------------------------------------------------------

  ~/LCS/LCS/InputForm.Designer.cs
  -------------------------------
  Partial class of InputForm.
  The input window for this application
  This partial class provides only the user interface for the InputForm


  Methods
  -------
  protected override void Dispose(bool disposing)
    parameters:
      true: if the instance of this input form will be disposed
      false: if it will not be disposed
    return: N/A

    System genetrated method, used to disposed the instance of this class

  private void InitializeInputBox()
    parameters: N/A
    return: N/A

    This method initialized all components in this input box includes all input boxes, buttons and background colors
    should be called when input form is first generated

  ------------------------------------------------------------------------------

  ~/LCS/LCS/InputForm.cs
  ----------------------
  Partial class of InputForm
  This partial class provides the constructor and Eventhandler for all components in this class

  Methods
  -------
  public InputForm(Service service)
    parameters:
      Service service: instance of service class which controls logics of this app
    return: N/A

  constructor method of this class

  private void textBox1_TextChanged(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Eventhandler method for first input box in input form

  private void textBox2_TextChanged(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/

    Eventhandler
     method for second input box in input form

  private void textBox3_TextChanged(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    EventHandler method for third input box in input form

  private void InputForm_Click(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Onclick method for input form
    hide warning message if clicked on anywhere of this form.

  private void inputButton_Click(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Onclick method for input button.
    when the button is clicked, check if the input channel is valid
    if input is valid, hide input form, display main form, if not, display warning msg

  ------------------------------------------------------------------------------

  ~/LCS/LCS/MainForm.cs
  ---------------------
  Partial class of MainForm
  This partial class provides the constructor and EventHandlers for all components in this class

  Methods
  -------
  public MainForm(LCS.Logic.Service service, int numOfComponents)
    parameters:
      LCS.Logic.Service service: instance of service class which controls all logics
      int numOfComponents: total number of components(or channels)
    return: N/A

    This is the constructor method of this class

  private void goButton_Click(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Go button onclick listener

  private void transitionInputBox_TextChanged(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    InputBox text change listener

  private void switchButton_Click(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Switch button onclick listener

  private void addFixtureButton_Click(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Add fixture button onclick listener, this method is not implemented yet

  private void exitButton_Click(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    exit button onclick listener

  ------------------------------------------------------------------------------

  ~/LCS/LCS/MainForm.Designer.cs
  ------------------------------
  Partial class of MainForm. The main GUI of this application.
  This partial class provides only the user interface for the MainForm

  Methods
  -------
  protected override void Dispose(bool disposing)
    parameters:
      true: if the instance of this input form will be disposed
      false: if it will not be disposed
    return: N/A

  System genetrated method, used to disposed the instance of this class

  private void InitializeComponent()
    parameters: N/A
    return: N/A

    This method only sets the attribute of the mainform. It will not add any component to mainform

  private void generateComponents(int numOfComponents)
    parameters:
      int numOfComponents: total number of sliders needed
    return: N/A

    This method adds all components needed for mainform including sliders


  private void generateCurrentScenePanel()
    parameters: N/A
    return: N/A

    This method initializes the current scene panel

  private void generateNextScenePanel()
    parameters: N/A
    return: N/A

    This method initializes the next scene panel

  private void generateGoPanel()
    parameters: N/A
    return: N/A

    This method initializes the panel where go button is located

  private void generateNamePanel()
    parameters: N/A
    return: N/A

    This method initializes the fixture name panel

  private void generateAddressPanel()
    parameters: N/A
    return: N/A

    This method initializes the address panel

  private void generateAddFixtureButton()
    parameters: N/A
    return: N/A

    This method generates the addFixture button

  private void generateExitButton()
    parameters: N/A
    return: N/A

    This method generates the exit button

  private void generateSceneTextPanel(Point location, string text)
    parameters:
      Point location: An instance of Point class represents the location of the Label
      string text: The text displays in this label
    return: N/A

    This method generates the labels "Current Scene" and "Next Scene" and placed them in designated location

  private void addStartAddress(string address, int fixtureNameId)
    parameters: N/A
    return: N/A

    This method adds start address to the address panel

  *The rest methods in this class are some getter and setter methods*

  ------------------------------------------------------------------------------

  ~/LCS/LCS/Component.cs
  ----------------------
  Components class. This class is inherited from Panel class
  Every Component consists of one slider, numeric up down, and name input box
  All components will have an unique id and a common data array where their values are stored in specific location of the data array associating to their id

  Methods
  -------
  public Component(string[,] data, Control.ControlCollection control, int id)
    parameters:
      string[,] data: two dimensional array that used to store slider data
      Control.ControlCollection control: control of the some panel, used to add this component to certain panel
      int id: id that associates with this component
    return: N/A

    Constructor method of the class. This method calls generateComponent()

  private void generateComponent()
    parameters: N/A
    return: N/A

    generate all parts in this components by calling generateTrackBar(), generateNumericUpDown(), and generateInputBox() method

  private void generateTickValues()
    parameters: N/A
    return: N/A

    generate the tick values for the slider

  private void generateTrackBar()
    parameters: N/A
    return: N/A

    generate slider for this component

  private void generateNumericUpDown()
    parameters: N/A
    return: N/A

    generate numeric up down for this component

  private void generateInputBox()
    parameters: N/A
    return: N/A

    generate name input box for this component

  private void trackBar1_Scroll(object sender, System.EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    onScroll EventHandler for the slider in this component

  private void numericUpDown_ValueChanged(object sender, EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    onChange EventHandler for the numeric up down in this component

  private void name_ValueChanged(object sender, System.EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    onChange EventHandler for the input box in this component

  private void storeData()
    parameters: N/A
    return: N/A

    This method stores slider value in certain location in data array

  private void calculatePoints()
    parameters: N/A
    return: N/A

    This method calculates the location of the component according to their id

  public void setValue(int value, string name)
    parameters:
      int value: slider value of the component
      string name: component name
    return: N/A

    Sets the value of track bar, numberic up down, and channel name of this component according to the input

  ------------------------------------------------------------------------------

  ~/LCS/LCS/FixtureNameLabel.cs
  -----------------------------
  FixtureNameLabel class. This class is inherited from Panel class
  This class consists an unique id, one label and EventHandlers for this label

  Methods
  -------
  public FixtureNameLabel(Service service, Panel panel, string name, int id)
    parameters:
      Service service: service object that controls all logics
      Panel panel: panel that contains this label
      string name: content of the label
      int id: id of this label
    return: N/A

    Constructor method of this class

  private void addFixtureName(string name, int id)
  parameters:
    string name: content of the label
    int id: id of this label
  return: N/A

  This method generates a label in specific location and add it to the panel

  private void fixtureName_MouseEnter(object sender, System.EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Mouse Enter EventHandler for this label, this uses together with Mouse Leave EventHandler to perform Mouse Hover effect

  private void fixtureName_MouseLeave(object sender, System.EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    Mouse Leave Eventhandler for this label, this uses together with Mouse Enter Eventhandler to perform Mouse Hover effect

  private void fixtureName_MouseClick(object sender, System.EventArgs e)
    parameters:
      EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
      Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
      the sender and EventArgs are parameter passed by the system. We don't need to pass those two parameters when called this method
      https://msdn.microsoft.com/en-us/library/system.eventargs.aspx
    return: N/A

    onClicked Eventhandler for this label. This method is not implemented yet


  ------------------------------------------------------------------------------

  ~/LCS/LCS/OpenDMX.cs
  --------------------
  This is outside API. The specific instruction and example can be found:
  https://www.enttec.com/us/products/controls/dmx-usb/open-dmx-usb/

  ------------------------------------------------------------------------------


--------------------------------------------------------------------------------------------------------------------------------------------------------
Support
-------
If you have any question or concern about our software, you can always find us on our Gitter Chat Room:  https://gitter.im/TheatricallyInclined/LCS?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge
Or email any of us:
Rong Yang: ryang5@buffalo.edu
Alex Killion: apkillio@buffalo.edu
Zack Bowen: zackbowe@buffalo.edu

If you find any bugs in our software, please you can report it as an issue in our GitHub: https://github.com/TheatricallyInclined/LCS/issues or inform us in Gitter Chat Room.
Our website is: http://www.acsu.buffalo.edu/~ryang5/

