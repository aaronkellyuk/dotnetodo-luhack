Imports ToDoLogic

Public Class MainWindow
    Private toDoList As New ToDoList()

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        toDoList.AddItem(txtNewItem.Text)
        UpdateList()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        toDoList.RemoveItem(lstItems.SelecetedItem.ToString())
        UpdateList()
    End Sub

    Private Sub UpdateList()
        lstItems.DataSource = Nothing
        lstItems.DataSource = toDoList.GetItems()
    End Sub

End Class
