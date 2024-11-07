# Funciones del proyecto

- Crea perfil de cliente;
- Crea cuenta
- Genera transacciones
- Retorna datos del cliente
- Retorna datos de la cuenta
- Retorna historico de la cuenta

# Anotaciones

### Recomendaciones para utilizar las apis
### json

Se recomienda quitar el campo id en el json enviado, ya que este se general automaticamente en la base de datos
{
<s>"id": 0</s>,
  "nombre": "Pedro",
  "fechaNacimiento": "2024-11-07",
  "sexo": 1,
  "ingresos": 0
}

### Base de datos
    
Se incluye dentro del proyecto las migraciones para poder crear la base de datos junto con sus tablas utilizando los siguientes comandos

### Comandos

```javascript
add-migration
update-database
```
### Cadena de conexion 
Se incluye dentro del proyecto tambien la cadena de conexion en el archivo appsettings.json, cambiar a su servidor
```javascript
Server=MIPC;Database=demo;User Id=;Password=; Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false
```

## End
