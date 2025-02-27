Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports ToDoLogic
Imports System.Configuration

Public Class MainWindow
    Private toDoList As New ToDoList()
    Private cosmosDbHelper As CosmosDbHelper

    Private Async Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cosmosDbHelper = New CosmosDbHelper("your-connection-string", "your-database-name", "your-container-name")
        Await LoadToDoItems()
    End Sub

    Private Async Function LoadToDoItems() As Task
        Dim toDoItems As List(Of ToDoItem) = Await cosmosDbHelper.GetToDoItemsAsync()
        toDoItems.Sort(Function(x, y) x.Id.CompareTo(y.Id)) ' Sort by uid in ascending order
        lstToDoItems.DataSource = toDoItems
        lstToDoItems.DisplayMember = "Task"
    End Function

    Private Sub lstToDoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstToDoItems.SelectedIndexChanged
        If lstToDoItems.SelectedItem IsNot Nothing Then
            Dim selectedItem As ToDoItem = DirectCast(lstToDoItems.SelectedItem, ToDoItem)
            txtSelectedItem.Text = $"Task: {selectedItem.Task}{Environment.NewLine}Completed: {selectedItem.IsCompleted}"
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        toDoList.AddItem(New ToDoItem() With {.Task = txtNewItem.Text, .IsCompleted = False})
        UpdateList()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        toDoList.RemoveItem(DirectCast(lstItems.SelectedItem, ToDoItem))
        UpdateList()
    End Sub

    Private Sub UpdateList()
        lstItems.DataSource = Nothing
        lstItems.DataSource = toDoList.GetItems()
    End Sub
End Class