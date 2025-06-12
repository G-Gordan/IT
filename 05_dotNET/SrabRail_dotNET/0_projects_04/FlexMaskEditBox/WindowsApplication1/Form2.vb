Imports System.Globalization

Public Class Form2
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents FlexMaskEditBox1 As FlxMaskBox.FlexMaskEditBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
   Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtFormatString As System.Windows.Forms.TextBox
   Friend WithEvents txtPromptChar As System.Windows.Forms.TextBox
   Friend WithEvents txtSpecialChars As System.Windows.Forms.TextBox
   Friend WithEvents txtFlexTxt As System.Windows.Forms.TextBox
   Friend WithEvents txtMask As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.FlexMaskEditBox1 = New FlxMaskBox.FlexMaskEditBox()
      Me.txtFormatString = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ComboBox1 = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtMask = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtPromptChar = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtFlexTxt = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.TextBox5 = New System.Windows.Forms.TextBox()
      Me.CheckBox2 = New System.Windows.Forms.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtSpecialChars = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'FlexMaskEditBox1
      '
      Me.FlexMaskEditBox1.BackColor = System.Drawing.Color.Linen
      Me.FlexMaskEditBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.FlexMaskEditBox1.FocusBackColor = System.Drawing.Color.LightBlue
      Me.FlexMaskEditBox1.FocusForeColor = System.Drawing.Color.DarkBlue
      Me.FlexMaskEditBox1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FlexMaskEditBox1.ForeColor = System.Drawing.Color.DimGray
      Me.FlexMaskEditBox1.Location = New System.Drawing.Point(16, 11)
      Me.FlexMaskEditBox1.Name = "FlexMaskEditBox1"
      Me.FlexMaskEditBox1.SelTxtOnEnter = FlxMaskBox.FlexMaskEditBox.SelectTxt.Once
      Me.FlexMaskEditBox1.Size = New System.Drawing.Size(432, 25)
      Me.FlexMaskEditBox1.TabIndex = 0
      '
      'txtFormatString
      '
      Me.txtFormatString.Location = New System.Drawing.Point(482, 37)
      Me.txtFormatString.Name = "txtFormatString"
      Me.txtFormatString.Size = New System.Drawing.Size(101, 20)
      Me.txtFormatString.TabIndex = 1
      Me.txtFormatString.Text = "c"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(482, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(109, 28)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "FormatString"
      '
      'ComboBox1
      '
      Me.ComboBox1.Items.AddRange(New Object() {"AlfaNumeric", "Numeric", "Date"})
      Me.ComboBox1.Location = New System.Drawing.Point(481, 254)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(139, 21)
      Me.ComboBox1.TabIndex = 3
      Me.ComboBox1.Text = "ComboBox1"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(481, 228)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(73, 24)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Fieldype"
      '
      'txtMask
      '
      Me.txtMask.Location = New System.Drawing.Point(83, 68)
      Me.txtMask.Name = "txtMask"
      Me.txtMask.Size = New System.Drawing.Size(363, 20)
      Me.txtMask.TabIndex = 5
      Me.txtMask.Text = "(999g999g999d######)"
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(13, 67)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(65, 25)
      Me.Label3.TabIndex = 6
      Me.Label3.Text = "Mask"
      '
      'txtPromptChar
      '
      Me.txtPromptChar.Location = New System.Drawing.Point(484, 117)
      Me.txtPromptChar.Name = "txtPromptChar"
      Me.txtPromptChar.Size = New System.Drawing.Size(103, 20)
      Me.txtPromptChar.TabIndex = 7
      Me.txtPromptChar.Text = "_"
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(486, 92)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(104, 23)
      Me.Label4.TabIndex = 8
      Me.Label4.Text = "PromptChar"
      '
      'txtFlexTxt
      '
      Me.txtFlexTxt.Location = New System.Drawing.Point(484, 311)
      Me.txtFlexTxt.Name = "txtFlexTxt"
      Me.txtFlexTxt.Size = New System.Drawing.Size(132, 20)
      Me.txtFlexTxt.TabIndex = 10
      Me.txtFlexTxt.Text = "123,45"
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(482, 289)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(136, 22)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Text"
      '
      'TextBox5
      '
      Me.TextBox5.Location = New System.Drawing.Point(8, 102)
      Me.TextBox5.Multiline = True
      Me.TextBox5.Name = "TextBox5"
      Me.TextBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.TextBox5.Size = New System.Drawing.Size(440, 233)
      Me.TextBox5.TabIndex = 12
      Me.TextBox5.Text = "Valid MaskChars:" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(#) - (chr 48 - 57)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(9) - (chr 48 - 57) (-) minus sign" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
      "(?) - (chr 65 - 90) (chr 97 - 121)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(A)(C)  - (chr 65 - 90) (chr 97 - 121) (ch" & _
      "r 48 - 57)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(a)(c)  - (chr 65 - 90) (chr 97 - 121) (chr 48 - 57) (chr 32 )" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & _
      "(&) - (chr 32 - 126) (chr 128 - 255)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(\)  Next char will be no mask char" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(" & _
      ">) All chars next to the > sign will transformed in upper-case" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    until the ne" & _
      "xt mask char is an (<) or (\) or (|)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(}) Next 1 Char will transformed in uppe" & _
      "r-case" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(<) All chars next to the < sign will transformed in lower-case" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    u" & _
      "ntil the next mask char is an (>) or (\) or (|)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(|) Stops next chars from Upp" & _
      "er or Lower casing" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "({) Next 1 Char will transformed in lower-case" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(d)(D)  " & _
      "Decimal Point (#####d99) = 12345.67 or 12345,67  " & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(9) & "(depending on country settin" & _
      "gs)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(g)(G)  Group Seperator (##g###g###d##) = 12.345.678,90 or 12,345,678.90" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    (depending on country settings)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "(s)(S) DateSeperator (##s##s####) = 12-1" & _
      "2-2000 or 12/12/2000" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    (depending on country settings)"
      '
      'CheckBox2
      '
      Me.CheckBox2.Location = New System.Drawing.Point(482, 198)
      Me.CheckBox2.Name = "CheckBox2"
      Me.CheckBox2.Size = New System.Drawing.Size(142, 20)
      Me.CheckBox2.TabIndex = 13
      Me.CheckBox2.Text = "BeepOnError"
      '
      'GroupBox1
      '
      Me.GroupBox1.Location = New System.Drawing.Point(8, 348)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(619, 5)
      Me.GroupBox1.TabIndex = 14
      Me.GroupBox1.TabStop = False
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(488, 147)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(128, 20)
      Me.Label6.TabIndex = 15
      Me.Label6.Text = "SpecialChars"
      '
      'txtSpecialChars
      '
      Me.txtSpecialChars.Location = New System.Drawing.Point(481, 171)
      Me.txtSpecialChars.Name = "txtSpecialChars"
      Me.txtSpecialChars.Size = New System.Drawing.Size(142, 20)
      Me.txtSpecialChars.TabIndex = 16
      Me.txtSpecialChars.Text = ""
      '
      'Label7
      '
      Me.Label7.Location = New System.Drawing.Point(146, 378)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(305, 20)
      Me.Label7.TabIndex = 17
      Me.Label7.Text = "Label7"
      '
      'Label8
      '
      Me.Label8.Location = New System.Drawing.Point(146, 407)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(305, 19)
      Me.Label8.TabIndex = 18
      Me.Label8.Text = "Label8"
      '
      'Label9
      '
      Me.Label9.Location = New System.Drawing.Point(13, 376)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(129, 20)
      Me.Label9.TabIndex = 19
      Me.Label9.Text = "maskCharsInclude"
      '
      'Label10
      '
      Me.Label10.Location = New System.Drawing.Point(16, 405)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(126, 20)
      Me.Label10.TabIndex = 20
      Me.Label10.Text = "MaskCharsExclude"
      '
      'Label11
      '
      Me.Label11.Location = New System.Drawing.Point(146, 436)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(307, 17)
      Me.Label11.TabIndex = 21
      Me.Label11.Text = "Label11"
      '
      'Label12
      '
      Me.Label12.Location = New System.Drawing.Point(13, 433)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(127, 17)
      Me.Label12.TabIndex = 22
      Me.Label12.Text = "FormatedText"
      '
      'Form2
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(652, 466)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label12, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.txtSpecialChars, Me.Label6, Me.GroupBox1, Me.CheckBox2, Me.TextBox5, Me.Label5, Me.txtFlexTxt, Me.Label4, Me.txtPromptChar, Me.Label3, Me.txtMask, Me.Label2, Me.ComboBox1, Me.Label1, Me.txtFormatString, Me.FlexMaskEditBox1})
      Me.Name = "Form2"
      Me.Text = "FlexMaskEditBox Tester"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ComboBox1.SelectedIndex = 1
   End Sub

   Private Shadows Sub FlexMaskEditBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexMaskEditBox1.Enter
      resetFlx()
   End Sub

   Sub resetFlx()
      With FlexMaskEditBox1
         .PromptChar = txtPromptChar.Text
         .Mask = txtMask.Text
         .SetFormatString = txtFormatString.Text
         .FieldType = ComboBox1.SelectedIndex
         .Text = txtFlexTxt.Text
         .BeepOnError = CheckBox2.Checked
         .SpecialChars = txtSpecialChars.Text
      End With
   End Sub

   Private Shadows Sub FlexMaskEditBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexMaskEditBox1.Leave
      With FlexMaskEditBox1
         .MaskCharInclude = True
         Label7.Text = .Text
         .MaskCharInclude = False
         Label8.Text = .Text
         Label11.Text = .GetFormatedText
      End With

   End Sub

End Class
