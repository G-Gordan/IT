Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Cached GDI+ objects created in Form's constructor.
    ' Used in the event handlers for the custom column styles events.
    Private disabledBackBrush As Brush
    Private disabledTextBrush As Brush
    Private currentRowFont As Font
    Private currentRowBackBrush As Brush

    ' Grid tootips-  fields used by the grid's mousemove events to manage.
    '   Row specific tips - initialized in Form_Load, used in dataGrid1_MouseMove.
    Private hitRow As Integer
    Private toolTip1 As System.Windows.Forms.ToolTip

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
                disabledBackBrush.Dispose()
                disabledTextBrush.Dispose()
                currentRowFont.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents DataSet11 As CustomDataGrid.DataSet1
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataSet11 = New CustomDataGrid.DataSet1
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.DataSource = Me.DataSet11.Products
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(548, 377)
        Me.DataGrid1.TabIndex = 0
        '
        'DataSet11
        '
        Me.DataSet11.DataSetName = "DataSet1"
        Me.DataSet11.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice" & _
        ", UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=(local)\NetSDK;initial catalog=Northwind;integrated security=SSPI;per" & _
        "sist security info=False;packet size=4096"
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPr" & _
        "ice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@ProductNam" & _
        "e, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @Units" & _
        "OnOrder, @ReorderLevel, @Discontinued); SELECT ProductID, ProductName, SupplierI" & _
        "D, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLe" & _
        "vel, Discontinued FROM Products WHERE (ProductID = @@IDENTITY)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductName", System.Data.SqlDbType.NVarChar, 40, "ProductName"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SupplierID", System.Data.SqlDbType.Int, 4, "SupplierID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID", System.Data.SqlDbType.Int, 4, "CategoryID"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QuantityPerUnit", System.Data.SqlDbType.NVarChar, 20, "QuantityPerUnit"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsInStock", System.Data.SqlDbType.SmallInt, 2, "UnitsInStock"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, "UnitsOnOrder"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReorderLevel", System.Data.SqlDbType.SmallInt, 2, "ReorderLevel"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Discontinued", System.Data.SqlDbType.Bit, 1, "Discontinued"))
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, Categor" & _
        "yID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, U" & _
        "nitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @Reord" & _
        "erLevel, Discontinued = @Discontinued WHERE (ProductID = @Original_ProductID) AN" & _
        "D (CategoryID = @Original_CategoryID OR @Original_CategoryID IS NULL AND Categor" & _
        "yID IS NULL) AND (Discontinued = @Original_Discontinued) AND (ProductName = @Ori" & _
        "ginal_ProductName) AND (QuantityPerUnit = @Original_QuantityPerUnit OR @Original" & _
        "_QuantityPerUnit IS NULL AND QuantityPerUnit IS NULL) AND (ReorderLevel = @Origi" & _
        "nal_ReorderLevel OR @Original_ReorderLevel IS NULL AND ReorderLevel IS NULL) AND" & _
        " (SupplierID = @Original_SupplierID OR @Original_SupplierID IS NULL AND Supplier" & _
        "ID IS NULL) AND (UnitPrice = @Original_UnitPrice OR @Original_UnitPrice IS NULL " & _
        "AND UnitPrice IS NULL) AND (UnitsInStock = @Original_UnitsInStock OR @Original_U" & _
        "nitsInStock IS NULL AND UnitsInStock IS NULL) AND (UnitsOnOrder = @Original_Unit" & _
        "sOnOrder OR @Original_UnitsOnOrder IS NULL AND UnitsOnOrder IS NULL); SELECT Pro" & _
        "ductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsIn" & _
        "Stock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products WHERE (ProductID =" & _
        " @ProductID)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductName", System.Data.SqlDbType.NVarChar, 40, "ProductName"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SupplierID", System.Data.SqlDbType.Int, 4, "SupplierID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID", System.Data.SqlDbType.Int, 4, "CategoryID"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QuantityPerUnit", System.Data.SqlDbType.NVarChar, 20, "QuantityPerUnit"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsInStock", System.Data.SqlDbType.SmallInt, 2, "UnitsInStock"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, "UnitsOnOrder"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReorderLevel", System.Data.SqlDbType.SmallInt, 2, "ReorderLevel"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Discontinued", System.Data.SqlDbType.Bit, 1, "Discontinued"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProductID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CategoryID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Discontinued", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Discontinued", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProductName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_QuantityPerUnit", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "QuantityPerUnit", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReorderLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ReorderLevel", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SupplierID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SupplierID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitPrice", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsInStock", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitsInStock", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitsOnOrder", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"))
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM Products WHERE (ProductID = @Original_ProductID) AND (CategoryID = @O" & _
        "riginal_CategoryID OR @Original_CategoryID IS NULL AND CategoryID IS NULL) AND (" & _
        "Discontinued = @Original_Discontinued) AND (ProductName = @Original_ProductName)" & _
        " AND (QuantityPerUnit = @Original_QuantityPerUnit OR @Original_QuantityPerUnit I" & _
        "S NULL AND QuantityPerUnit IS NULL) AND (ReorderLevel = @Original_ReorderLevel O" & _
        "R @Original_ReorderLevel IS NULL AND ReorderLevel IS NULL) AND (SupplierID = @Or" & _
        "iginal_SupplierID OR @Original_SupplierID IS NULL AND SupplierID IS NULL) AND (U" & _
        "nitPrice = @Original_UnitPrice OR @Original_UnitPrice IS NULL AND UnitPrice IS N" & _
        "ULL) AND (UnitsInStock = @Original_UnitsInStock OR @Original_UnitsInStock IS NUL" & _
        "L AND UnitsInStock IS NULL) AND (UnitsOnOrder = @Original_UnitsOnOrder OR @Origi" & _
        "nal_UnitsOnOrder IS NULL AND UnitsOnOrder IS NULL)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProductID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CategoryID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Discontinued", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Discontinued", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProductName", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_QuantityPerUnit", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "QuantityPerUnit", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReorderLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ReorderLevel", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SupplierID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SupplierID", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitPrice", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsInStock", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitsInStock", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitsOnOrder", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Products", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ProductID", "ProductID"), New System.Data.Common.DataColumnMapping("ProductName", "ProductName"), New System.Data.Common.DataColumnMapping("SupplierID", "SupplierID"), New System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"), New System.Data.Common.DataColumnMapping("QuantityPerUnit", "QuantityPerUnit"), New System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"), New System.Data.Common.DataColumnMapping("UnitsInStock", "UnitsInStock"), New System.Data.Common.DataColumnMapping("UnitsOnOrder", "UnitsOnOrder"), New System.Data.Common.DataColumnMapping("ReorderLevel", "ReorderLevel"), New System.Data.Common.DataColumnMapping("Discontinued", "Discontinued")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 398)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "Form1"
        Me.Text = "Products"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create and cash some GDI+ objects that we are continually using.
        ' In our cell formatting.
        Me.disabledBackBrush = New SolidBrush(SystemColors.InactiveCaptionText)
        Me.disabledTextBrush = New SolidBrush(SystemColors.GrayText)
        Me.currentRowFont = New Font(Me.DataGrid1.Font.Name, Me.DataGrid1.Font.Size, FontStyle.Bold)
        Me.currentRowBackBrush = Brushes.DodgerBlue

        ' Read the data - normally you might call the Fill method
        '                 Me.SqlDataAdapter1.Fill(Me.DataSet11)
        ' but here we read directly from an XML file
        Me.DataSet11.ReadXml(GetPathTo("ProductsTable.XML"))

        ' Create an empty DataGridTableStyle & set mapping name to table.
        Dim tableStyle As New DataGridTableStyle()
        tableStyle.MappingName = "Products"

        ' Now create custom DataGridColumnSyle for each col we want to 
        '    appear in the grid and in the order that we want to see them
        '    Discontinued.
        Dim discontinuedCol As New ClickableBooleanColumn()
        discontinuedCol.MappingName = "Discontinued"
        discontinuedCol.HeaderText = "hi"
        discontinuedCol.Width = 30
        discontinuedCol.AllowNull = False ' turn off tristate
        AddHandler discontinuedCol.BoolValueChanged, AddressOf BoolCellClicked
        tableStyle.GridColumnStyles.Add(discontinuedCol)

        'ProductID
        Dim column As New FormattableTextBoxColumn()
        column.MappingName = "ProductID"
        column.HeaderText = "ID"
        column.Width = 30
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
        tableStyle.GridColumnStyles.Add(column)

        'ProductName
        column = New FormattableTextBoxColumn()
        column.MappingName = "ProductName"
        column.HeaderText = "Name"
        column.Width = 140
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
        tableStyle.GridColumnStyles.Add(column)
       
        'QuantityPerUnit
        column = New FormattableTextBoxColumn()
        column.MappingName = "QuantityPerUnit"
        column.HeaderText = "QuantityPerUnit"
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
       tableStyle.GridColumnStyles.Add(column)

        'UnitPrice
        column = New FormattableTextBoxColumn()
        column.MappingName = "UnitPrice"
        column.HeaderText = "UnitPrice"
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
        tableStyle.GridColumnStyles.Add(column)

        'UnitsInStock
        column = New FormattableTextBoxColumn()
        column.MappingName = "UnitsInStock"
        column.HeaderText = "UnitsInStock"
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
        tableStyle.GridColumnStyles.Add(column)
        
        'UnitsOnOrder
        column = New FormattableTextBoxColumn()
        column.MappingName = "UnitsOnOrder"
        column.HeaderText = "UnitsOnOrder"
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
        tableStyle.GridColumnStyles.Add(column)
        
        'ReorderLevel
        column = New FormattableTextBoxColumn()
        column.MappingName = "ReorderLevel"
        column.HeaderText = "ReorderLevel"
        AddHandler column.SetCellFormat, AddressOf FormatGridRow
        tableStyle.GridColumnStyles.Add(column)

        Me.DataGrid1.TableStyles.Add(tableStyle)

        ' Set up the grid tooltips.
        Me.hitRow = -1
        Me.toolTip1 = New ToolTip()
        Me.toolTip1.InitialDelay = 300
        AddHandler Me.DataGrid1.MouseMove, AddressOf dataGrid1_MouseMove
    End Sub

#Region "columnstyle event handlers"
    Private Sub BoolCellClicked(ByVal sender As Object, ByVal e As BoolValueChangedEventArgs)
        'Console.WriteLine("BoolCellClicked")
        Me.DataGrid1.EndEdit(Me.DataGrid1.TableStyles(0).GridColumnStyles("Discontinued"), e.Row, False)
        RefreshRow(e.Row)
        Me.DataGrid1.BeginEdit(Me.DataGrid1.TableStyles(0).GridColumnStyles("Discontinued"), e.Row)
    End Sub

    Private Sub FormatGridRow(ByVal sender As Object, ByVal e As DataGridFormatCellEventArgs)
        ' Conditionally set properties in e depending upon e.Row and e.Col.
        Dim discontinued As Boolean = CBool(IIf(e.Column <> 0, Me.DataGrid1(e.Row, 0), e.CurrentCellValue)) 'TODO: For performance reasons this should be changed to nested IF statements
        ' Check if discontinued?
        If e.Column > 0 AndAlso CBool(Me.DataGrid1(e.Row, 0)) Then 'discontinued?
            e.BackBrush = Me.disabledBackBrush
            e.ForeBrush = Me.disabledTextBrush
        ElseIf e.Column > 0 AndAlso e.Row = Me.DataGrid1.CurrentRowIndex Then 'currentrow?
            e.BackBrush = Me.currentRowBackBrush
            e.TextFont = Me.currentRowFont
        End If
    End Sub

#End Region




#Region "ToolTip Implementation"

    ' Checks mouse position to see if it is over a discontinued row, 
    '        or reorder row. If so, set the tiptext and reset the tooltip.
    Private Sub dataGrid1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim hti As DataGrid.HitTestInfo = Me.DataGrid1.HitTest(New Point(e.X, e.Y))
        Dim bmb As BindingManagerBase = Me.BindingContext(Me.DataGrid1.DataSource, Me.DataGrid1.DataMember)
        If hti.Row < bmb.Count AndAlso hti.Type = DataGrid.HitTestType.Cell AndAlso hti.Row <> hitRow Then
            If Not (Me.toolTip1 Is Nothing) AndAlso Me.toolTip1.Active Then
                Me.toolTip1.Active = False 'turn it off
            End If
            Dim tipText As String = ""
            If CBool(Me.DataGrid1(hti.Row, 0)) Then
                tipText = Me.DataGrid1(hti.Row, 2).ToString() + " discontinued"
                If tipText <> "" Then
                    'new hit row
                    hitRow = hti.Row
                    Me.toolTip1.SetToolTip(Me.DataGrid1, tipText)
                    Me.toolTip1.Active = True 'make it active so it can show itself
                Else
                    hitRow = -1
                End If
            Else
                hitRow = -1
            End If
        End If
    End Sub 'dataGrid1_MouseMove
#End Region

#Region "Grid Event Handlers"
    Private Sub dataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
        'if click on a discontinued row, then set currrentcell to checkbox
        If CBool(Me.DataGrid1(Me.DataGrid1.CurrentRowIndex, 0)) Then
            Me.DataGrid1.CurrentCell = New DataGridCell(Me.DataGrid1.CurrentRowIndex, 0)
        End If
        afterCurrentCellChanged = True
    End Sub 'dataGrid1_CurrentCellChanged

    Private afterCurrentCellChanged As Boolean = False

    Private Sub dataGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        Dim pt As Point = Me.DataGrid1.PointToClient(Control.MousePosition)
        Dim hti As DataGrid.HitTestInfo = Me.DataGrid1.HitTest(pt)
        Dim bmb As BindingManagerBase = Me.BindingContext(Me.DataGrid1.DataSource, Me.DataGrid1.DataMember)
        If afterCurrentCellChanged AndAlso hti.Row < bmb.Count AndAlso hti.Type = DataGrid.HitTestType.Cell AndAlso hti.Column = 0 Then
            Me.DataGrid1(hti.Row, 0) = Not CBool(Me.DataGrid1(hti.Row, 0))
            RefreshRow(hti.Row)
        End If
        afterCurrentCellChanged = False
    End Sub 'dataGrid1_Click

#End Region

#Region "Helper Methods"
    ' Forces a repaint of given row.
    Private Sub RefreshRow(ByVal row As Integer)
        Dim rect As Rectangle = Me.DataGrid1.GetCellBounds(row, 0)
        rect = New Rectangle(rect.Right, rect.Top, Me.DataGrid1.Width, rect.Height)
        Me.DataGrid1.Invalidate(rect)
    End Sub 'RefreshRow

    ' Look back up in the project path for file...
    Private Function GetPathTo(ByVal name As String) As String
        Dim i As Integer
        For i = 0 To 3
            If System.IO.File.Exists(name) Then
                Exit For
            End If
            name = "..\" + name
        Next i
        Return name
    End Function 'GetPathTo

#End Region

End Class
