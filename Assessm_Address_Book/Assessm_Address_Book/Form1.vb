Public Class Form1

    Private friends As New Collection
    Dim person As Address_collector

    'Adding new record
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim fr_found As Boolean = False
        Dim myfriend As New Address_collector

        For Each person In friends
            If person.get_name = TextBox1.Text Then
                fr_found = True
            End If
        Next

        If fr_found Then
            MsgBox("The name: " + TextBox1.Text + " is already on a list!", MsgBoxStyle.Exclamation, "Name on a list")
            lstFriends.SelectedItem = person.get_name
            txtBoxAddress.Text = person.get_address
        Else
            myfriend.get_name = TextBox1.Text
            myfriend.get_address = TextBox2.Text
            friends.Add(myfriend)
            lstFriends.Items.Add(myfriend.get_name)
            MsgBox("The friend " + TextBox1.Text +
                   " and address " + TextBox2.Text + " were added.", MsgBoxStyle.Information, "Done.")
            TextBox1.Clear()
            TextBox2.Clear()

        End If
    End Sub

    'Select a name from the list box
    Private Sub lstFriends_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFriends.SelectedIndexChanged

        If lstFriends.SelectedIndex >= 0 Then
            person = friends.Item(lstFriends.SelectedIndex + 1)
            txtBoxAddress.Text = person.get_address
        End If

    End Sub

    'Find the name in the notebook
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        Dim fr_found As Boolean = False

        For Each person In friends
            If person.get_name = TextBox1.Text Then
                TextBox2.Text = person.get_address
                fr_found = True
                lstFriends.SelectedItem = person.get_name
                txtBoxAddress.Text = person.get_address
            End If
        Next
        If fr_found Then
            MsgBox("Found")
        Else
            MsgBox("Not Found")
        End If

    End Sub

    'Delete selected or found record
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If friends.Count = 0 Or lstFriends.SelectedIndex = -1 Then
            MsgBox("No name selected to delete")

        Else
            MsgBox("The friend " + lstFriends.SelectedItem +
                    " removed", MsgBoxStyle.Information, "Done.")
            friends.Remove(lstFriends.SelectedIndex + 1)
            lstFriends.Items.RemoveAt(lstFriends.SelectedIndex)
            txtBoxAddress.Clear()
        End If
    End Sub

    'Clear all records
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim response As MsgBoxResult
        response = MsgBox("Would you like to clear ALL records?", MsgBoxStyle.YesNo, "Clear ALL?")
        If response = MsgBoxResult.Yes Then
            friends.Clear()
            txtBoxAddress.Clear()
            lstFriends.Items.Clear()

        End If
    End Sub

    'Exit the application
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

End Class
