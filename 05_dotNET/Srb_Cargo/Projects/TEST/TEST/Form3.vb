Class Form3
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TextBox3.Text = TextBox1.Text \ TextBox2.Text
        TextBox4.Text = TextBox1.Text Mod TextBox2.Text

    End Sub
End Class
