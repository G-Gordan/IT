Imports System
Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmListKorGrupe
    Inherits System.Windows.Forms.Form

    Private dv As DataView = New DataView
    Private iiRowsAffected As Integer = 0   'Records affected by SQLDataAdapters Query
    Private rowIndex As Integer = 0         'DataView Row Index for Find Method
    Private rowFilter As String = ""        'Filtrira redove u DataView
    Private aSortList() As String = {"KorGrupa", "Korisnicka Grupa"}
    Private AscSort As String = "ASC"

    Dim WithEvents miDodaj As New MenuItem
    Dim WithEvents miIzmeni As New MenuItem
    Dim WithEvents miObrisi As New MenuItem

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
    Friend WithEvents lblSort As System.Windows.Forms.Label
    Friend WithEvents cbSort As System.Windows.Forms.ComboBox
    Friend WithEvents txtPretraga As System.Windows.Forms.TextBox
    Friend WithEvents dgrd As System.Windows.Forms.DataGrid
    Friend WithEvents btnObrisi As System.Windows.Forms.Button
    Friend WithEvents btnIzmeni As System.Windows.Forms.Button
    Friend WithEvents btnDodaj As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSort As System.Windows.Forms.Button
    Friend WithEvents dgrds As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents KorGrupa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Napomena As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblSort = New System.Windows.Forms.Label
        Me.cbSort = New System.Windows.Forms.ComboBox
        Me.txtPretraga = New System.Windows.Forms.TextBox
        Me.dgrd = New System.Windows.Forms.DataGrid
        Me.dgrds = New System.Windows.Forms.DataGridTableStyle
        Me.KorGrupa = New System.Windows.Forms.DataGridTextBoxColumn
        Me.Napomena = New System.Windows.Forms.DataGridTextBoxColumn
        Me.btnObrisi = New System.Windows.Forms.Button
        Me.btnIzmeni = New System.Windows.Forms.Button
        Me.btnDodaj = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnSort = New System.Windows.Forms.Button
        CType(Me.dgrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSort
        '
        Me.lblSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblSort.Location = New System.Drawing.Point(72, 8)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(32, 16)
        Me.lblSort.TabIndex = 0
        Me.lblSort.Text = "Sort: "
        Me.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbSort
        '
        Me.cbSort.Location = New System.Drawing.Point(112, 8)
        Me.cbSort.Name = "cbSort"
        Me.cbSort.Size = New System.Drawing.Size(121, 21)
        Me.cbSort.TabIndex = 1
        '
        'txtPretraga
        '
        Me.txtPretraga.Location = New System.Drawing.Point(240, 8)
        Me.txtPretraga.Name = "txtPretraga"
        Me.txtPretraga.Size = New System.Drawing.Size(112, 20)
        Me.txtPretraga.TabIndex = 3
        Me.txtPretraga.Text = ""
        '
        'dgrd
        '
        Me.dgrd.AllowSorting = False
        Me.dgrd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrd.CaptionVisible = False
        Me.dgrd.DataMember = ""
        Me.dgrd.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrd.Location = New System.Drawing.Point(0, 32)
        Me.dgrd.Name = "dgrd"
        Me.dgrd.ReadOnly = True
        Me.dgrd.RowHeaderWidth = 15
        Me.dgrd.Size = New System.Drawing.Size(600, 264)
        Me.dgrd.TabIndex = 4
        Me.dgrd.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgrds})
        '
        'dgrds
        '
        Me.dgrds.AllowSorting = False
        Me.dgrds.BackColor = System.Drawing.SystemColors.Info
        Me.dgrds.DataGrid = Me.dgrd
        Me.dgrds.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.KorGrupa, Me.Napomena})
        Me.dgrds.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dgrds.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrds.MappingName = "KorGrupe"
        Me.dgrds.ReadOnly = True
        '
        'KorGrupa
        '
        Me.KorGrupa.Format = ""
        Me.KorGrupa.FormatInfo = Nothing
        Me.KorGrupa.HeaderText = "KORISNICKA GRUPA"
        Me.KorGrupa.MappingName = "KorGrupa"
        Me.KorGrupa.ReadOnly = True
        Me.KorGrupa.Width = 130
        '
        'Napomena
        '
        Me.Napomena.Format = ""
        Me.Napomena.FormatInfo = Nothing
        Me.Napomena.HeaderText = "N A P O M E N A"
        Me.Napomena.MappingName = "Napomena"
        Me.Napomena.ReadOnly = True
        Me.Napomena.Width = 450
        '
        'btnObrisi
        '
        Me.btnObrisi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnObrisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnObrisi.Location = New System.Drawing.Point(536, 304)
        Me.btnObrisi.Name = "btnObrisi"
        Me.btnObrisi.Size = New System.Drawing.Size(56, 23)
        Me.btnObrisi.TabIndex = 5
        Me.btnObrisi.Text = "&Obriši"
        '
        'btnIzmeni
        '
        Me.btnIzmeni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIzmeni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnIzmeni.Location = New System.Drawing.Point(472, 304)
        Me.btnIzmeni.Name = "btnIzmeni"
        Me.btnIzmeni.Size = New System.Drawing.Size(56, 23)
        Me.btnIzmeni.TabIndex = 6
        Me.btnIzmeni.Text = "&Izmeni"
        '
        'btnDodaj
        '
        Me.btnDodaj.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDodaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnDodaj.Location = New System.Drawing.Point(408, 304)
        Me.btnDodaj.Name = "btnDodaj"
        Me.btnDodaj.Size = New System.Drawing.Size(56, 23)
        Me.btnDodaj.TabIndex = 7
        Me.btnDodaj.Text = "&Dodaj"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(0, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(32, 32)
        Me.btnPrint.TabIndex = 1
        '
        'btnSort
        '
        Me.btnSort.Location = New System.Drawing.Point(32, 0)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(32, 32)
        Me.btnSort.TabIndex = 2
        '
        'frmListKorGrupe
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 333)
        Me.Controls.Add(Me.btnSort)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDodaj)
        Me.Controls.Add(Me.btnIzmeni)
        Me.Controls.Add(Me.btnObrisi)
        Me.Controls.Add(Me.dgrd)
        Me.Controls.Add(Me.txtPretraga)
        Me.Controls.Add(Me.cbSort)
        Me.Controls.Add(Me.lblSort)
        Me.Name = "frmListKorGrupe"
        Me.Text = "Lista Podataka"
        CType(Me.dgrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub txtPretraga_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPretraga.TextChanged
        subKreirajFilter(txtPretraga.Text)
        subGridSortFilter(aComboVK(aSortList, cbSort.Text), rowFilter, AscSort)
    End Sub
    Private Sub subKreirajFilter(ByVal trazeniTekst As String)
        rowFilter = aComboVK(aSortList, cbSort.Text) & " LIKE " & "'" & trazeniTekst & "%'"
    End Sub
    Private Sub subComboSortPuni()
        Dim ii As Int16 = 0
        For ii = 0 To aSortList.Length - 1
            If (ii Mod 2 > 0) Then
                Me.cbSort.Items.Add(aSortList(ii))
            End If
        Next
    End Sub
    Private Sub subAdapterPuni()
        'Dim da As New SqlDataAdapter("SELECT KorGrupa , Napomena FROM KorGrupe", cnRoba)
        Dim da As New SqlDataAdapter("SELECT * FROM KorGrupe", cnRoba)
        KorGrupe.dt.Clear()
        KorGrupe.ds.Clear()
        Try
            iiRowsAffected = da.Fill(KorGrupe.ds, "KorGrupe")
            dv = KorGrupe.ds.Tables("KorGrupe").DefaultView
        Catch e As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub subAzurirajDataTable(ByVal rowProcessed As DataRow)
        Select Case KorGrupe.Akcija
            Case "dodaj"
                'rowProcessed("KorGrupa") = f_KorGrupa
                'rowProcessed("Napomena") = f_Napomena
                'rowProcessed("TStamp") = ts()
                'rowProcessed("Korisnik") = gv_Korisnik
                'dt.Rows.Add(rowProcessed)
                KorGrupe.dt.Rows.Add(New Object() {KorGrupe.f_KorGrupa, KorGrupe.f_Napomena, KorGrupe.f_ts, gv_Korisnik})
            Case "izmeni"
                rowProcessed.Item("KorGrupa") = KorGrupe.f_KorGrupa
                rowProcessed.Item("Napomena") = KorGrupe.f_Napomena
                rowProcessed.Item("TStamp") = KorGrupe.f_ts
                rowProcessed.Item("Korisnik") = gv_Korisnik
            Case "obrisi"
                KorGrupe.dt.Rows.Remove(rowProcessed)
            Case Else
                MsgBox("Nepoznata Akcija: " & KorGrupe.Akcija & " !?!")
        End Select
        dgrd.Refresh()
    End Sub
    Private Sub subGridSortFilter(ByVal ipOrderBy As String, ByVal ipFilter As String, ByVal ipAscDesc As String)
        If ipOrderBy = "DEFAULT" Then
            cbSort.Text = aSortList(1)  'Po Default-u uzima prvi element za Sortiranje liste
            ipAscDesc = "ASC"
            ipFilter = ""
        End If
        ipOrderBy = aComboVK(aSortList, cbSort.Text)
        Try
            dv.Sort = ipOrderBy & " " & ipAscDesc
            dv.RowFilter = ipFilter
            dgrd.DataSource = dv
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Greška u programu")
        End Try
    End Sub
    Private Sub subSelect(ByVal ipKorGrupa As String)
        Dim rowIndex As Integer
        rowIndex = dv.Find(ipKorGrupa)
        dgrd.Select(rowIndex)
        dgrd.CurrentCell = New DataGridCell(rowIndex, 0)
    End Sub
    Private Sub subDodaj()
        Dim rowProcessed As DataRow
        KorGrupe.Akcija = "dodaj"
        Dim frmUnos As New frmUnos

        frmUnos.ShowDialog()
        frmUnos.Dispose()
        If KorGrupe.dwClosed Then    'Ako je slog stvarno upisan u bazu
            KorGrupe.dwClosed = 0
            rowProcessed = KorGrupe.dt.NewRow()
            subAzurirajDataTable(rowProcessed)
            subGridSortFilter("DEFAULT", "", "")
            subSelect(KorGrupe.f_KorGrupa)
            'subGridSortFilter(cbSort.Text, rowFilter, AscSort)
        End If
    End Sub
    Private Sub subIzmeni()
        'Dim keyCellValue = dgrd.Item(dgrd.CurrentCell.RowNumber, 0)
        'Dim dr As DataRow = dt.Select("KorGrupa = " & keyCellValue)
        Dim dr() As DataRow   'Definise se kao NIZ jer Select metod moze vratiti vise od 1 reda
        Dim keyCellValue As String = ""
        Try
            keyCellValue = dgrd.Item(dgrd.CurrentCell.RowNumber, 0)
            dr = KorGrupe.dt.Select("KorGrupa = '" & keyCellValue & "'")
            'Posto se selektuje samo jedan red - dr(0) znaci prvi selektovani red u nizu
            KorGrupe.f_KorGrupa = dr(0).Item("KorGrupa")
            KorGrupe.f_Napomena = dr(0).Item("Napomena")
            KorGrupe.Akcija = "izmeni"
            Dim frmUnos = New frmUnos
            frmUnos.ShowDialog()
            subAzurirajDataTable(dr(0))
            subGridSortFilter(aComboVK(aSortList, cbSort.Text), "", "ASC") 'Prikazuje Grid sortiran po prvom polju - ascending
        Catch eSQL As SqlException
            MsgBox(eSQL.Message)
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub subObrisi()
        Dim GreskaOpis As String = ""
        Dim keyCellValue As String = ""
        Dim dr As DataRow()   'Definise se kao NIZ jer Select metod moze vratiti vise od 1 reda
        Dim ynObrisi As MsgBoxResult  ' Potvrda za brisanje sloga

        ynObrisi = MsgBox("Da li stvarno želite da obrišete slog ?", MsgBoxStyle.YesNo, "Brisanje Sloga")
        If ynObrisi = MsgBoxResult.Yes Then
            Try
                keyCellValue = dgrd.Item(dgrd.CurrentCell.RowNumber, 0)
                dr = KorGrupe.dt.Select("KorGrupa = " & keyCellValue)
                KorGrupe.f_KorGrupa = dr(0).Item("KorGrupa")
                KorGrupe.Akcija = "obrisi"
                subKorGrupeMan(GreskaOpis)
                If Trim(GreskaOpis) <> "" Then
                    MsgBox(GreskaOpis, MsgBoxStyle.OKOnly, "Transakcijska Greška")
                Else
                    subAzurirajDataTable(dr(0))
                End If
            Catch
                MsgBox(Err.Description)
            End Try
        End If
    End Sub
    Private Sub frmListKorGrupe_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        subContextMenu()
        KorGrupe.ds.Tables.Add(KorGrupe.dt)
        'dt.Columns.Add("KorGrupa", Type.GetType("System.String"))
        'dt.Columns.Add("Napomena", Type.GetType("System.String"))
        'dt.Columns.Add("TStamp", Type.GetType("System.String"))
        'dt.Columns.Add("Korisnik", Type.GetType("System.String"))
        subComboSortPuni()
        subAdapterPuni()
        Me.cbSort.Text = aSortList(1)
        subGridSortFilter(aComboVK(aSortList, cbSort.Text), rowFilter, AscSort)  'Popunjava Grid sortirano po prvom polju - ascending
    End Sub
    Private Sub btnDodaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDodaj.Click
        subDodaj()
    End Sub
    Private Sub btnIzmeni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzmeni.Click
        'Dim rowNumber As Integer = dgrd.CurrentCell.RowNumber
        subIzmeni()
    End Sub
    Private Sub btnObrisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObrisi.Click
        subObrisi()
    End Sub
    Private Sub cbSort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSort.SelectedIndexChanged
        txtPretraga.Text = ""
        AscSort = "ASC"
        btnSort.Image = imageAsc
        subGridSortFilter(aComboVK(aSortList, cbSort.Text), rowFilter, AscSort)
        dgrd.Focus()
    End Sub
    Private Sub btnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSort.Click
        If AscSort = "ASC" Then
            AscSort = "DESC"
            btnSort.Image = imageDesc
        Else
            AscSort = "ASC"
            btnSort.Image = imageAsc
        End If
        subGridSortFilter(cbSort.Text, rowFilter, AscSort)
    End Sub
    Private Sub dgrd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrd.DoubleClick
        subIzmeni()
    End Sub

    'Pop-Up Menu - ContextMenu
    Private Sub subContextMenu()
        Dim mnuContextMenu As New ContextMenu

        miDodaj.Text = "&Dodaj"
        miIzmeni.Text = "&Izmeni"
        miObrisi.Text = "&Obrisi"

        mnuContextMenu.MenuItems.Add(miDodaj)
        mnuContextMenu.MenuItems.Add(miIzmeni)
        mnuContextMenu.MenuItems.Add(miObrisi)

        Me.dgrd.ContextMenu = mnuContextMenu
    End Sub
    Private Sub miDodaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDodaj.Click
        subDodaj()
    End Sub
    Private Sub miIzmeni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miIzmeni.Click
        subIzmeni()
    End Sub
    Private Sub miObrisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miObrisi.Click
        subObrisi()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Dim frmRep As New frmRep

        'frmRep.ShowDialog()
        'frmRep.Dispose()
    End Sub
End Class