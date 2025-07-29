Imports System
Imports System.IO
Imports System.Linq.Expressions

Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim nombre, imc2 As String
        Dim peso, altura, imc As Double
        Do
            Try
                Console.Clear()
                Console.WriteLine("Menu de opciones:")
                Console.WriteLine("1. calcular IMC")
                Console.WriteLine("2. Ver historial")
                Console.WriteLine("3. Borrar Historial")
                Console.WriteLine("4.Salir")
                Console.WriteLine("seleccione una opcion")
                opcion2 = Console.ReadKey()
                opcion = opcion2.KeyChar
                Console.Clear()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Select Case opcion
                Case "1"
                    Try
                        Console.Clear()
                        Console.WriteLine("ingrese su nombre")
                        nombre = Console.ReadLine()
                        Console.WriteLine("Ingrese su peso (kg):")
                        peso = Double.Parse(Console.ReadLine())
                        Console.WriteLine("ingrese su altura (m)")
                        altura = Double.Parse(Console.ReadLine())
                        Console.Clear()
                        imc = peso / (altura * altura)
                        Dim resultado As String = If(imc <= 18.5, "Bajo de peso",
                            If(imc <= 24.9, "peso normal",
                            If(imc <= 29.9, "sobrepeso",
                            If(imc <= 34.9, "obesidad grado1",
                            If(imc <= 39.9, "obesidad grado 2", "obesidad grado 3(obesidad morbida")))))
                        imc2 = imc.ToString("F4")
                        Console.WriteLine("su IMC es:" & imc2 & "" & resultado)
                        Dim historial As StreamWriter
                        historial = File.AppendText("historial_imc.txt")
                        historial.WriteLine(nombre & "," & peso & "," & altura & "," & imc2 & "," & resultado)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial")
                    Catch ex As DivideByZeroException
                        Console.WriteLine("la altura no puede ser cero")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("historial_imc.txt")
                        Console.WriteLine("Nombre, peso, altura, IMC, Resultado")
                        Do Until historial.EndOfStream
                            Console.WriteLine(historial.ReadLine())
                        Loop
                        historial.Close()
                    Catch ex As FileNotFoundException
                        Console.WriteLine("El archivo de historial no existe")
                    End Try
                    Console.WriteLine("")
                    Console.WriteLine("presione cualquier tecla")
                    Console.ReadKey()
                Case "3"
                    Dim historial As String = "Historial_imc.txt"
                    File.Delete(historial)
                    Console.WriteLine("borrar historial")
                    Console.ReadKey()
                Case "4"
                    Console.Clear()
                    Console.WriteLine("hasta pronto")
                    Exit Do
                    Console.ReadKey()
                Case Else
                    Console.WriteLine("opcion no valida.")
            End Select
        Loop
    End Sub






End Module





















