﻿/*
 * Creado por SharpDevelop.
 * Usuario: BETY
 * Fecha: 20/11/2014
 * Hora: 12:38 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using MySql.Data.MySqlClient;
namespace practica5
{
	
	
	
	class Program : MySQL
	{
		public void mostrarTodos(){

	this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string telefono1 = myReader ["telefono"].ToString();
	            string email1 = myReader ["email"].ToString();
	            Console.WriteLine("ID: " + id +
				                  " Código: " + codigo +" Nombre: " + nombre + "telefono :" + telefono1 + "email :" + email1);
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}
		public void insertarRegistroNuevo(string nombre1, string telefono1,string email ,string codigo){
			this.abrirConexion();
			string sql = "INSERT INTO `alumno` (`nombre`, `telefono`,`email`,`codigo`) VALUES ('" + nombre1 + "', '" + telefono1 + "','" + email+"','"+codigo+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			
		}
		public void eliminarRegistroPorId(string id){
			this.abrirConexion();
			string sql = "DELETE FROM `alumno` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);			this.cerrarConexion();
		}
		private string querySelect(){
			return "SELECT * " +
	           	"FROM alumno";
		
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		
		
		
		
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Program p = new Program ();
			// TODO: Implement Functionality Here
			string nombre1,telefono1,email1,codigo1,registro;
			int opc;
			do{
				Console.WriteLine("1 para ingresar registros");
				Console.WriteLine("2 para ver registros");
				Console.WriteLine("3 para eliminar registros");
				Console.WriteLine("4 para salir");
				opc =int.Parse (Console.ReadLine());
				switch(opc)
				{
				case 1 :
					
					Console.WriteLine("ingrese nombre");
			nombre1=Console.ReadLine();
			Console.WriteLine("ingrese telefono");
			telefono1=Console.ReadLine();
			Console.WriteLine("ingrese email");
			email1=Console.ReadLine();
			Console.WriteLine("ingrese codigo");
			codigo1=Console.ReadLine();
		
			
	        p.insertarRegistroNuevo(nombre1,telefono1,email1,codigo1);
	        Console.WriteLine("registro agregado;");
				break;
				case 2 :
	        p.mostrarTodos();
	             break;
	            case 3 :
	             Console.WriteLine("ingrese id de registro para borrar");
	             registro=Console.ReadLine();
	             p.eliminarRegistroPorId(registro);
	             Console.WriteLine("registro eliminado!!!");
	             break;
				}
			
		    
			}while(opc!=4);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
