using HotelApp;
namespace HotelTest;

public class Tests
{
    [Test]
    public void CalcularPrecio_Cliente_VIP_AplicaDescuento()
    {
        // Arrange 
        var reserva = new h1();
        reserva.v = true; 
        reserva.d = 2;    
        reserva.t = 1;    

        // Act 
        decimal resultado = reserva.procesar();

        // Assert 
        // El resultado debería ser menor al precio base por ser VIP
        Assert.Less(resultado, 100); 
    }

    [Test]
    public void CalcularPrecio_EstanciaLarga_AplicaDescuento()
    {
        //Arrange
        var reserva = new h1();
        reserva.t = 2;
        reserva.d = 10;
        reserva.v = false;
        reserva.b = 0;
        
        //Act
        decimal resultado = reserva.procesar();
        
        //Assert
        Assert.That(resultado, Is.LessThan(750));
    }
    [Test]
    public void CalcularPrecio_ClienteVIP_Y_EstanciaLarga_AplicaAmbosDescuentos()
    {
        // Arrange
        var reserva = new h1();
        reserva.t = 3;    
        reserva.d = 15;   
        reserva.v = true; 

        // Act
        decimal resultado = reserva.procesar();

        // Assert
        decimal precioBase = 2250;
        Assert.That(resultado, Is.LessThan(precioBase));
    }
}