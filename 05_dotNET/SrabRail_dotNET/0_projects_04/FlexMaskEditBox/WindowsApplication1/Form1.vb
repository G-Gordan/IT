Imports System.Text.RegularExpressions
Imports FlxMaskBox


Public Class Form1
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
   Friend WithEvents FlexMaskEditBox1 As FlexMaskEditBox
   Friend WithEvents FlexMaskEditBox2 As FlexMaskEditBox
   Friend WithEvents FlexMaskEditBox3 As FlexMaskEditBox
   Friend WithEvents FlexMaskEditBox4 As FlexMaskEditBox
   Friend WithEvents FlexMaskEditBox5 As FlexMaskEditBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents Label9 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.FlexMaskEditBox1 = New FlxMaskBox.FlexMaskEditBox()
      Me.FlexMaskEditBox2 = New FlxMaskBox.FlexMaskEditBox()
      Me.FlexMaskEditBox3 = New FlxMaskBox.FlexMaskEditBox()
      Me.FlexMaskEditBox4 = New FlxMaskBox.FlexMaskEditBox()
      Me.FlexMaskEditBox5 = New FlxMaskBox.FlexMaskEditBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.CheckBox1 = New System.Windows.Forms.CheckBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Button2 = New System.Windows.Forms.Button()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'FlexMaskEditBox1
      '
      Me.FlexMaskEditBox1.BackColor = System.Drawing.Color.PapayaWhip
      Me.FlexMaskEditBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.FlexMaskEditBox1.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.NUMERIC
      Me.FlexMaskEditBox1.FocusBackColor = System.Drawing.Color.PaleTurquoise
      Me.FlexMaskEditBox1.FocusForeColor = System.Drawing.Color.DodgerBlue
      Me.FlexMaskEditBox1.Location = New System.Drawing.Point(216, 24)
      Me.FlexMaskEditBox1.Mask = "999g999g999d###"
      Me.FlexMaskEditBox1.MaskCharInclude = False
      Me.FlexMaskEditBox1.Name = "FlexMaskEditBox1"
      Me.FlexMaskEditBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.FlexMaskEditBox1.SelTxtOnEnter = FlxMaskBox.FlexMaskEditBox.SelectTxt.Always
      Me.FlexMaskEditBox1.SetFormatString = "C"
      Me.FlexMaskEditBox1.Size = New System.Drawing.Size(128, 20)
      Me.FlexMaskEditBox1.TabIndex = 0
      Me.FlexMaskEditBox1.Text = "88,55"
      '
      'FlexMaskEditBox2
      '
      Me.FlexMaskEditBox2.BackColor = System.Drawing.Color.PapayaWhip
      Me.FlexMaskEditBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.FlexMaskEditBox2.FieldType = FlxMaskBox.FlexMaskEditBox._FieldType.DATE_
      Me.FlexMaskEditBox2.FocusBackColor = System.Drawing.Color.PaleTurquoise
      Me.FlexMaskEditBox2.FocusForeColor = System.Drawing.Color.DodgerBlue
      Me.FlexMaskEditBox2.Location = New System.Drawing.Point(216, 58)
      Me.FlexMaskEditBox2.Mask = "##S##S####"
      Me.FlexMaskEditBox2.Name = "FlexMaskEditBox2"
      Me.FlexMaskEditBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.FlexMaskEditBox2.SelTxtOnEnter = FlxMaskBox.FlexMaskEditBox.SelectTxt.Once
      Me.FlexMaskEditBox2.SetFormatString = "D"
      Me.FlexMaskEditBox2.Size = New System.Drawing.Size(220, 20)
      Me.FlexMaskEditBox2.TabIndex = 1
      Me.FlexMaskEditBox2.Text = "12-12-1212"
      '
      'FlexMaskEditBox3
      '
      Me.FlexMaskEditBox3.BackColor = System.Drawing.Color.PapayaWhip
      Me.FlexMaskEditBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.FlexMaskEditBox3.FocusBackColor = System.Drawing.Color.PaleTurquoise
      Me.FlexMaskEditBox3.FocusForeColor = System.Drawing.Color.DodgerBlue
      Me.FlexMaskEditBox3.Location = New System.Drawing.Point(216, 93)
      Me.FlexMaskEditBox3.Mask = "#### >??"
      Me.FlexMaskEditBox3.Name = "FlexMaskEditBox3"
      Me.FlexMaskEditBox3.Size = New System.Drawing.Size(220, 20)
      Me.FlexMaskEditBox3.TabIndex = 2
      '
      'FlexMaskEditBox4
      '
      Me.FlexMaskEditBox4.BackColor = System.Drawing.Color.PapayaWhip
      Me.FlexMaskEditBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.FlexMaskEditBox4.FocusBackColor = System.Drawing.Color.PaleTurquoise
      Me.FlexMaskEditBox4.FocusForeColor = System.Drawing.Color.DodgerBlue
      Me.FlexMaskEditBox4.Location = New System.Drawing.Point(216, 125)
      Me.FlexMaskEditBox4.Mask = "(>????<????) (}?{?}?{?)        (999g999g999g999d99)"
      Me.FlexMaskEditBox4.Name = "FlexMaskEditBox4"
      Me.FlexMaskEditBox4.Size = New System.Drawing.Size(244, 20)
      Me.FlexMaskEditBox4.TabIndex = 3
      '
      'FlexMaskEditBox5
      '
      Me.FlexMaskEditBox5.BackColor = System.Drawing.Color.PapayaWhip
      Me.FlexMaskEditBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.FlexMaskEditBox5.ErrorForeColor = System.Drawing.Color.SeaGreen
      Me.FlexMaskEditBox5.FocusBackColor = System.Drawing.Color.PaleTurquoise
      Me.FlexMaskEditBox5.FocusForeColor = System.Drawing.Color.DodgerBlue
      Me.FlexMaskEditBox5.Location = New System.Drawing.Point(217, 157)
      Me.FlexMaskEditBox5.Name = "FlexMaskEditBox5"
      Me.FlexMaskEditBox5.Size = New System.Drawing.Size(220, 20)
      Me.FlexMaskEditBox5.TabIndex = 4
      '
      'Button1
      '
      Me.Button1.BackColor = System.Drawing.Color.DarkSalmon
      Me.Button1.ForeColor = System.Drawing.Color.Black
      Me.Button1.Location = New System.Drawing.Point(467, 220)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(101, 17)
      Me.Button1.TabIndex = 5
      Me.Button1.TabStop = False
      Me.Button1.Text = "Get Value"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(7, 245)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(286, 18)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Included MaskChars"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(300, 245)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(270, 15)
      Me.Label2.TabIndex = 7
      Me.Label2.Text = "Excluded MaskChars"
      '
      'CheckBox1
      '
      Me.CheckBox1.Location = New System.Drawing.Point(219, 183)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(179, 22)
      Me.CheckBox1.TabIndex = 8
      Me.CheckBox1.TabStop = False
      Me.CheckBox1.Text = "Only exit on valid input"
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(13, 160)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(170, 20)
      Me.Label5.TabIndex = 20
      Me.Label5.Text = "Valid eMail address"
      '
      'Label3
      '
      Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.Label3.Location = New System.Drawing.Point(13, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(194, 20)
      Me.Label3.TabIndex = 19
      Me.Label3.Text = "Value Between 201.13 And 4027.55"
      '
      'Label4
      '
      Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.Label4.Location = New System.Drawing.Point(13, 124)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(186, 19)
      Me.Label4.TabIndex = 23
      Me.Label4.Text = "Just a Fantasy Input"
      '
      'Label6
      '
      Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.Label6.Location = New System.Drawing.Point(11, 60)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(192, 19)
      Me.Label6.TabIndex = 22
      Me.Label6.Text = "Valid Date Between 1980 and 2010"
      '
      'Label7
      '
      Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.Label7.Location = New System.Drawing.Point(13, 95)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(191, 19)
      Me.Label7.TabIndex = 21
      Me.Label7.Text = "ZipCode "
      '
      'Label8
      '
      Me.Label8.Location = New System.Drawing.Point(8, 266)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(282, 20)
      Me.Label8.TabIndex = 24
      Me.Label8.Text = "GetFormatText"
      '
      'Button2
      '
      Me.Button2.BackColor = System.Drawing.Color.Moccasin
      Me.Button2.ForeColor = System.Drawing.Color.Black
      Me.Button2.Location = New System.Drawing.Point(409, 6)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(161, 25)
      Me.Button2.TabIndex = 25
      Me.Button2.Text = "FlexMaskEditBox Tester"
      '
      'Label9
      '
      Me.Label9.Location = New System.Drawing.Point(12, 216)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(220, 20)
      Me.Label9.TabIndex = 28
      '
      'Form1
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(573, 291)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.Button2, Me.Label8, Me.Label4, Me.Label6, Me.Label7, Me.Label5, Me.Label3, Me.CheckBox1, Me.Label2, Me.Label1, Me.Button1, Me.FlexMaskEditBox5, Me.FlexMaskEditBox4, Me.FlexMaskEditBox3, Me.FlexMaskEditBox2, Me.FlexMaskEditBox1})
      Me.Name = "Form1"
      Me.Text = "FlexMaskEdit Examples"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private flx As FlexMaskEditBox

   Private Shadows Sub FlexMaskEditBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles FlexMaskEditBox1.Leave, FlexMaskEditBox2.Leave, _
            FlexMaskEditBox3.Leave, FlexMaskEditBox4.Leave, _
            FlexMaskEditBox5.Leave

      flx = CType(sender, FlexMaskEditBox)
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      flx.MaskCharInclude = False
      Label2.Text = flx.Text
      flx.MaskCharInclude = True
      Label1.Text = flx.Text
      Label8.Text = flx.GetFormatedText()
   End Sub

   Private Sub FlexMaskEditBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FlexMaskEditBox1.Validating, FlexMaskEditBox2.Validating, FlexMaskEditBox3.Validating, FlexMaskEditBox5.Validating
      Dim fmb As FlxMaskBox.FlexMaskEditBox = CType(sender, FlxMaskBox.FlexMaskEditBox)
      If fmb Is FlexMaskEditBox1 Then
         Try
            Dim Value As Decimal = Decimal.Parse(fmb.Text)
            If Value < 201.13 OrElse Value > 4027.55 Then
               fmb.ErrorTxt = "Value MUST between 201.13 and 4027.55"
               If CheckBox1.Checked Then e.Cancel = True
            Else
               fmb.ErrorTxt = ""
            End If
         Catch 'normal, this will never been evaluate . .  
            fmb.ErrorTxt = "There is no Valid Value given"
            If CheckBox1.Checked Then e.Cancel = True
         End Try
      ElseIf fmb Is FlexMaskEditBox2 Then
         Try
            Dim dt As DateTime = DateTime.Parse(fmb.Text)
            If dt.Year < 1980 OrElse dt.Year > 2010 Then
               fmb.ErrorTxt = "The Range of valid Years must be between 1980 an 2010"
               If CheckBox1.Checked Then e.Cancel = True
            Else
               fmb.ErrorTxt = ""
            End If
         Catch
            fmb.ErrorTxt = "Not A Valid Date, Try Again!"
            If CheckBox1.Checked Then e.Cancel = True
         End Try
      ElseIf fmb Is FlexMaskEditBox3 Then
         With fmb '6 chars must given, so delete the spaces and count the chars
            If .Text.Replace(" ", "").Length < 6 Then
               .ErrorTxt = "Not All Characters Are Given"
               If CheckBox1.Checked Then e.Cancel = True
            Else
               .ErrorTxt = ""
            End If
         End With
      ElseIf fmb Is FlexMaskEditBox5 Then
         With fmb
            If Not Regex.IsMatch(.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") Then
               .ErrorTxt = "No valid Email address"
               If CheckBox1.Checked Then e.Cancel = True
            Else
               .ErrorTxt = ""
            End If
         End With
      End If
   End Sub

   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim ctl As Object
      For Each ctl In Me.Controls
         If TypeOf ctl Is FlexMaskEditBox Then
            CType(ctl, FlexMaskEditBox).ToolTip = "Mask: " & CType(ctl, FlexMaskEditBox).Mask & vbCrLf & vbCrLf & "Read the Readme.txt file"
         End If
      Next
      Label9.Text = "Version: " & FlexMaskEditBox1.Version
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      Dim f As New Form2()
      f.Show()
   End Sub

   End Class
