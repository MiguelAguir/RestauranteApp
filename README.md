# RestauranteApp

Sistema de gestión de restaurante construido con .NET y Entity Framework Core usando enfoque Database First.

## Descripción

Aplicación de consola en .NET que modela la base de datos de un restaurante usando Entity Framework Core con MySQL (Database First). Las entidades incluyen clientes, mesas, reservas, pedidos, productos, ingredientes y facturas. Proyecto académico en etapa inicial, actualmente con el modelo de datos completo y listo para agregar lógica de negocio.

## Tecnologías

- **.NET 9** / Aplicación de consola
- **Entity Framework Core 9** con MySQL (Pomelo)
- **Database First** (modelo generado desde base de datos existente)
- **MySQL 9**

## Estructura del proyecto

```
RestauranteApp/
  Models/     -- Entidades generadas desde la base de datos
  Data/       -- RestauranteContext (DbContext con configuración de entidades)
  Program.cs  -- Punto de entrada de la aplicación
```

### Modelo de datos

| Entidad             | Descripción                                    |
|---------------------|------------------------------------------------|
| Cliente             | Datos del cliente (nombre, email, teléfono)    |
| Mesa                | Mesa del restaurante (número, capacidad, estado) |
| Reserva             | Reserva de mesa por cliente (fecha, horario)   |
| Pedido              | Pedido realizado por un cliente en una mesa    |
| Itempedido          | Producto solicitado en un pedido (cantidad, precio) |
| Producto            | Producto del menú (tipo: plato, bebida, postre) |
| Ingrediente         | Ingrediente con stock y umbral mínimo          |
| Ingredienteproducto | Relación muchos a muchos entre ingrediente y producto |
| Factura             | Factura generada a partir de un pedido         |
| Alertainventario    | Vista de alertas de inventario bajo            |

### Estados del sistema

- **Mesa:** `libre`, `ocupada`, `reservada`
- **Pedido:** `pendiente`, `preparando`, `entregado`, `cancelado`
- **Reserva:** `confirmada`, `modificada`, `cancelada`
- **Factura:** `generada`, `pagada`, `anulada`
- **Producto tipo:** `plato`, `bebida`, `postre`

## Instalación

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/MiguelAguir/RestauranteApp.git
   cd RestauranteApp
   ```

2. Configurar la cadena de conexión a MySQL en `RestauranteContext.cs` (línea 42):
   ```csharp
   optionsBuilder.UseMySql("server=localhost;database=actividad05;user=root;password=...", ...);
   ```

3. Ejecutar:
   ```bash
   dotnet run
   ```

## Estado del proyecto

En etapa inicial. El modelo de datos y el contexto de Entity Framework están completos. Pendiente la implementación de la lógica de negocio y la interfaz de consola.
