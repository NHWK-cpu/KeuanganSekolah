Imports System.Windows.Forms
Imports System.Drawing

' Kelas ComboBox dengan Placeholder (komponen buatan sendiri)
Public Class PHComboBox
    Inherits ComboBox

    Private DefaultColor As Color
    Private _placeHolderText As String
    Private isPlaceHolderActive As Boolean = False

    Public Property PlaceHolderText As String
        Get
            Return _placeHolderText
        End Get
        Set(value As String)
            _placeHolderText = value
            SetPlaceholder()
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        DefaultColor = Me.ForeColor

        ' Atur event handler
        AddHandler Me.GotFocus, AddressOf RemovePlaceholder
        AddHandler Me.LostFocus, AddressOf SetPlaceholder

        ' Supaya bisa mengetik teks bebas
        Me.DropDownStyle = ComboBoxStyle.DropDown
    End Sub

    Private Sub SetPlaceholder()
        If String.IsNullOrEmpty(Me.Text) AndAlso Not String.IsNullOrEmpty(_placeHolderText) Then
            isPlaceHolderActive = True
            Me.ForeColor = Color.Gray
            Me.Text = _placeHolderText
        End If
    End Sub

    Private Sub RemovePlaceholder()
        If isPlaceHolderActive Then
            isPlaceHolderActive = False
            Me.Text = ""
            Me.ForeColor = DefaultColor
        End If
    End Sub

    ' Jika pengguna memilih item dari dropdown, ubah warna teks
    Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
        MyBase.OnSelectedIndexChanged(e)
        isPlaceHolderActive = False
        Me.ForeColor = DefaultColor
    End Sub

    ' Pastikan placeholder muncul ketika kontrol pertama kali dibuat
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        SetPlaceholder()
    End Sub

End Class
