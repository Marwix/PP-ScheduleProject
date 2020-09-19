Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            Timer1.Start()
            Start(0)

            Dim firstDate As DateTime = New DateTime(2014, 11, 10)
            Dim secondDate As DateTime = New DateTime(2014, 10, 7)
            Dim result As Int16 = DateTime.Compare(firstDate, secondDate)

            If result > 0 Then
                'MsgBox("Not expired")
            End If
            If result < 0 Then
                MsgBox("Utgångsdatumet för detta program har gått ut. Var vänlig och säg till Allan att förnya programmet till det senaste schemat för att hålla uppe schema anläggningen. Programmet kommer nu att stängas.", MsgBoxStyle.Critical, "Expired")
                Environment.Exit(1)
            End If
        Catch
            Me.Close()
        End Try
    End Sub

    Protected Friend Sub Start(ByVal i As ULong)
        Dim coll As Byte = 255
        Win32.AllocConsole()
        Console.WriteLine("Laddar schemat..." & vbNewLine)
        Try
            Do Until i > &HA
                Console.WriteLine(i & Environment.NewLine)
                System.Threading.Thread.Sleep(125)
                i += 1
            Loop
            Console.WriteLine("Schemat har laddats - " & Date.Now)
            Win32.FreeConsole()
        Catch ex As OutOfMemoryException : MsgBox(ex.ToString) : End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Date.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("http://www.novasoftware.se/webviewer/(S(4hkj4b551t20zu3pxgr4ep45))/design1.aspx?schoolid=55700&code=452266")
    End Sub
End Class

Public Class Win32
    <DllImport("kernel32.dll")> _
    Public Shared Function AllocConsole() As [Boolean]
    End Function
    <DllImport("kernel32.dll")> _
    Public Shared Function FreeConsole() As [Boolean]
    End Function
End Class