Public Class Form1

    Dim labelbox As TextBox
    'Dim disptxtbox As TextBox
    Dim newbox As TextBox
    Public boxes(10, 10) As TextBox

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'object is called but not exist at that time
        'reorganise the codes
        'load all the objects first the call

        'This textbox is for input (massive)
        'disptxtbox = New TextBox
        'disptxtbox.Size = New Drawing.Size(1000, 20)
        'disptxtbox.Location = New Point(20, 30)
        'Me.Controls.Add(disptxtbox)
        'disptxtbox.Name = "xx"
        'disptxtbox.Text = "Hello"

        'This textboxes is for labels for column
        Dim lposcol As Integer = 20
        For a As Integer = 65 To 74
            labelbox = New TextBox
            labelbox.Size = New Drawing.Size(100, 20)
            labelbox.Location = New Point(lposcol, 70)
            lposcol += 100
            labelbox.Text = Chr(a)
            labelbox.TextAlign = HorizontalAlignment.Center
            Me.Controls.Add(labelbox)
        Next

        'This textboxes is for labels for row
        Dim lposrow As Integer = 90
        For b As Integer = 1 To 10
            labelbox = New TextBox
            labelbox.Size = New Drawing.Size(20, 20)
            labelbox.Location = New Point(0, lposrow)
            lposrow += 20
            labelbox.Text = b
            labelbox.TextAlign = HorizontalAlignment.Center
            Me.Controls.Add(labelbox)
        Next

        'This textbox is for cells
        Dim rowcounter As Integer = 90
        For i As Integer = 1 To 10
            Dim colcounter As Integer = 20
            For j As Integer = 1 To 10
                'create a new textbox and set its properties
                newbox = New TextBox
                newbox.Size = New Drawing.Size(100, 20)
                newbox.Location = New Point(colcounter, rowcounter)
                colcounter += 100
                AddHandler newbox.TextChanged, AddressOf TextBox_TextChanged
                boxes(i, j) = newbox
                Me.Controls.Add(newbox)
            Next
            rowcounter += 20
        Next

    End Sub

    Private Sub TextBox_TextChanged(sender As System.Object, e As System.EventArgs)
        'when you modify the contents of any textbox, the name of that textbox and
        'its current contents will be displayed in the title bar
        Dim box As TextBox = DirectCast(sender, TextBox)
        disptextbox.Text = box.Text
    End Sub

    'Public Sub Form1_Testt(sender As Object, e As EventArgs) Handles MyBase.MouseMove
    'For i As Integer = 1 To 10
    'For j As Integer = 1 To 10
    'If (boxes(i, j).Text <> Nothing) Then
    'disptextbox.Text = boxes(i, j).Text
    'End If
    'Next
    'Next
    'End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles disptextbox.TextChanged
        Dim a As String = disptextbox.Text
        If (GetChar(a, 1) = "=") Then
            boxes(1, 1).Text = "Hooray"
            'boxes selected - focus/onClick
            'triggered calc by =
            'select textbox by clicking 
            'append to box.focus()
            'slice - sub()
            'calculate - switch statement
        End If
    End Sub

    Public focussedTextBox As TextBox

    Public Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        For Each control As Control In Me.Controls
            If control.GetType.Equals(GetType(TextBox)) Then
                Dim textBox As TextBox = control
                AddHandler textBox.Enter, Sub() focussedTextBox = textBox
            End If
        Next
    End Sub

    Public Sub sulaisu()
        Dim len As Integer = focussedTextBox.Text.Length
        Dim str As String = focussedTextBox.Text
        Dim separators() As String = {"+", "-", "*", "/", " "}
        Dim result() As String = str.Split(separators, StringSplitOptions.None)
        For Each s As String In result
            '    MessageBox.Show(s)
        Next
        MessageBox.Show(len)

    End Sub

    Private Sub Generate_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sulaisu()
    End Sub
End Class
