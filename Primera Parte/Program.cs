using System.Runtime.CompilerServices;

//Variable para el menú
bool bandera = false; 

//Constantes con la cantidad de asientos y filas 
const int filas = 10;
const int asientos = 10;

//Matriz 
char[,] anfiteatro = new char[filas,asientos];

//Cargo el mapa del anfiteatro (filas y asientos con "L" --> "Libre") 
for (int i = 0; i < filas; i++){
    for (int j = 0; j < asientos; j++){
        anfiteatro[i, j] = 'L';
    }
}

//Funcion que dibuja el mapa de asientos y filas
void dibujarMapa()
{
    for (int i = 0; i < filas; i++)     //Recorre todo la matriz
    {
        for (int j = 0; j < asientos; j++)
        {
            Console.Write(anfiteatro[i, j]);
        }
        Console.WriteLine();
    }
}

//Función para que no de NULL al parsear a int una entrada. 
int ingresarValorNumerico()
{
    while (true)
    {
        string entrada = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(entrada) && int.TryParse(entrada, out int numero)) return int.Parse(entrada);
        //Compruebo que no sea algo vacío, NULL o incapaz de parsearlo a int
    }
}

//Reserva asientos 
int reservarAsiento()
{
    Console.Write("Ingrese fila: ");
    int filaOpc = ingresarValorNumerico() - 1; 
    Console.Write("Ingrese asiento: "); 
    int asientoOpc = ingresarValorNumerico() - 1;
    // ingresarValorNumerico - 1 para que el usuario pueda ingresar del 1 al 10, como pide la consigna, y que 
    //se tomen correctamente los valores en la matriz, que va del 0 al 9. 

    //Verifica que se encuentre libre 
    if ( -1 < filaOpc && filaOpc < 10 && -1 < asientoOpc && asientoOpc < 10)
    {
        if (anfiteatro[filaOpc, asientoOpc].CompareTo('L') == 0)
        {
            anfiteatro[filaOpc, asientoOpc] = 'X'; // "X" --> Ocupado
            return 0;
        }
        else { return 1; }
    }
    else return -1;

    /*
    *Devuelve -1 --> La reserva no se pudo hacer porque se ingresó un valor no permitido. 
    *Devuelve 1 --> La reserva no se pudo hacer porque el asiento ya está ocupado. 
    *Devuelve 0 --> La reserva se realizó con éxito.
    */
}

//Menú 
while (!bandera)
{
    Console.WriteLine("Menú de reservas");
    Console.WriteLine("1 - Ver asientos disponibles");
    Console.WriteLine("2 - Reservar asientos");
    Console.WriteLine("3 - Salir del programa");
    int seleccionMenu =  ingresarValorNumerico();
    Console.Clear();
    switch (seleccionMenu){
            case 1:
                dibujarMapa();
                Console.WriteLine("Apriete enter para volver al menú.");
                Console.ReadLine();
                break;
            case 2:
                    int opc = reservarAsiento(); //Toma el return de la función 
                    while (opc != 0)
                    {
                    Console.Clear();
                     if (opc == 1)
                        {
                         Console.WriteLine("No se pudo reservar el asiento porque ya está ocupado. Intente nuevamente.");
                        } else
                            {
                            Console.WriteLine("No se pudo reservar el asiento porque ingresó un valor invalido. Intente nuevamente.Las filas y asientos van desde el 1 al 10.");
                            }
                    opc = reservarAsiento();
                    }
                    Console.Clear();
                    Console.WriteLine("Reserva realizada con éxito. Apriete enter volver al menú.");
                    Console.ReadLine();
                   break;
            case 3:
                return; 
                break;
                         }
        Console.Clear();

}