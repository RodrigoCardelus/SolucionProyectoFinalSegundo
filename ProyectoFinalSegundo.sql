Use Master	
Go


CREATE DATABASE ProyectoFinalSegundo
ON(
	NAME=ProyectoFinalSegundo,
	FILENAME='C:\ProyectoFinalSegundo.mdf'
)
go


--creacion de usuario IIS para que el sitio pueda acceder a la bd-------------------------------------------
Use Master 
Go

Create Login[IIS APPPOOL\DefaultAppPool] From Windows
go


Use ProyectoFinalSegundo
GO

Create USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
go


------- Creacion de Tablas-------------------------------------------------------------------------------------
USE ProyectoFinalSegundo
go

-----Creacion de Rol----------------------------------------------------------------------------------------
Create Role MiRole;
go

GRANT CREATE SCHEMA TO MiRole;
GO
GRANT ALTER ANY USER TO MiRole;
GO
GRANT ALTER ANY ROLE TO MiRole;
GO



Create Table Usuario
(
   UsuarioLog varchar(20) Primary Key NOT NULL,
   Contraseña varchar(10) NOT NULL,
   NombreC varchar(20) NOT NULL,
   Activo bit not null Default(1) -- 1 esta activo // 0 tiene baja logica
)
Go



Create Table Juegos
(
  Codigo int Primary Key Identity NOT NULL,
  UsuarioLog varchar(20) NOT NULL
  Foreign Key References Usuario(UsuarioLog),
  Dificultad varchar(10) CHECK (Dificultad  IN ('FACIL', 'MEDIO', 'DIFICIL')),
  FechaC datetime NOT NULL default GetDate()
)
Go



Create Table Jugar
(
  FechaHora datetime default GetDate() Primary Key,
  Codigo int NOT NULL Foreign Key References Juegos(Codigo),
  Nombre varchar(20)NOT NULL,
  Puntaje int NOT NULL
  CHECK (Puntaje>0),
)
Go


Create Table Categorias
(
  CodigoC varchar(4)Primary Key NOT NULL
  check (CodigoC like'[a-z][a-z][a-z][a-z]'),
  Nombre varchar(20) NOT NULL,
  Activo bit not null Default(1) -- 1 esta activo // 0 tiene baja logica
)
Go



Create Table Preguntas
(
  CodigoP varchar(5) Primary Key NOT NULL
  check (CodigoP like '[0-9A-Z][0-9A-Z][0-9A-Z][0-9A-Z][0-9A-Z]'),
  CodigoC varchar(4) Foreign Key References Categorias(CodigoC),
  Texto varchar(50) NOT NULL,
  Puntaje int NOT NULL
  CHECK (Puntaje>=1 AND Puntaje<=10)
)
Go




Create Table PreguntasdeUnJuego
(
  CodigoP varchar(5) NOT NULL Foreign Key (CodigoP) References Preguntas(CodigoP),
  Codigo int NOT NULL Foreign Key (Codigo) REFERENCES Juegos(Codigo),
  Primary Key(CodigoP, Codigo)
)
Go





Create Table Respuestas
(
  CodigoInterno int NOT NULL,
  CodigoP varchar(5) NOT NULL,
  TextoR varchar(50) NOT NULL,
  Resultado bit NOT NULL,
  Primary Key (CodigoInterno,CodigoP),
  Foreign Key (CodigoP) REFERENCES Preguntas(CodigoP)
)
Go




----------------------------SP--------------------------------------------------------------------
---SP AltaUsuario------
Create Procedure AltaUsuario @UsuarioLog varchar(20), @Contraseña varchar(10),@NombreC varchar(50) AS
BEGIN
       Declare @VarSentencia varchar(200)
		
	 if (Exists(Select * From Usuario Where UsuarioLog = @UsuarioLog AND Activo = 0))
		Begin
			    Begin TRAN
		  		--recordar actualizar datos no solo activar
			    update Usuario
				Set Contraseña = @Contraseña, NombreC = @NombreC, Activo = 1
			    where UsuarioLog = @UsuarioLog
				if (@@ERROR <> 0)
		        Begin
			        Rollback TRAN
			        return -1
		        end 
				 
				--primero creo el usuario de logueo
		        Set @VarSentencia = 'CREATE LOGIN [' +  @UsuarioLog + '] WITH PASSWORD = ' + QUOTENAME(@Contraseña, '''')
		        Exec (@VarSentencia)
		        if (@@ERROR <> 0)
		        Begin
			        Rollback TRAN
			        return -2
		        end
		
		        ---segundo creo usuario bd
		        Set @VarSentencia = 'Create User [' +  @UsuarioLog + '] From Login [' + @UsuarioLog + ']'
		        Exec (@VarSentencia)
		        if (@@ERROR <> 0)
		        Begin
			       Rollback TRAN
			       return -3
		        end
		        
		    
	    		Commit TRAN	
	    		EXEC ..sp_addrolemember 'MiRole', @UsuarioLog;
	    		
	    		
				return 1 --devolucion clasica, para el usuario final es lo mismo
	    end
		
		-- si ya existe  -- no puedo darlo de alta (validacion de siempre)
		if(Exists(select * From Usuario where UsuarioLog = @UsuarioLog AND Activo = 1))
		   return -4
		   
		Begin TRAN
		
		
        --No existe la PK - lo puedo agregar
		Insert Usuario (UsuarioLog, Contraseña, NombreC) values (@UsuarioLog, @Contraseña, @NombreC)
		if (@@ERROR <> 0)
		Begin
			Rollback TRAN
			return -5
		end
		
	
	   Set @VarSentencia = 'CREATE LOGIN [' +  @UsuarioLog + '] WITH PASSWORD = ' + QUOTENAME(@Contraseña, '''')
       Exec(@VarSentencia)
       if (@@ERROR <> 0)
	   Begin
			Rollback TRAN
			return -6
	   end
		
	
	   Set @VarSentencia = 'Create User [' +  @UsuarioLog + '] From Login [' + @UsuarioLog + ']'
       Exec(@VarSentencia)
       
       if (@@ERROR <> 0)
	   Begin
			Rollback TRAN
			return -7
	   end	
		
	  Commit TRAN
	  
 
	 EXEC ..sp_addrolemember 'MiRole', @UsuarioLog;
	 
    

	  RETURN 1
End
GO


Grant exec  on ProyectoFinalSegundo.dbo.AltaUsuario TO MiRole;
GO






-----------Baja Usuario----------------------------------------------------------------------------------
Create Procedure BajaUsuario @UsuarioLog varchar(20) AS
BEGIN
     Declare @VarSentencia varchar(200)
       
     if(Not Exists(Select * From Usuario Where UsuarioLog = @UsuarioLog))
		Begin
			return -1
		end
	
			
     if(Exists(Select * From Juegos where UsuarioLog = @UsuarioLog))
  	     Begin
		       Begin TRAN		
		   --baja logica -- se usa update para modificar atributo de activo
		       update Usuario set Activo = 0 where UsuarioLog = @UsuarioLog
			    if(@@ERROR <> 0)
	            Begin
			        Rollback TRAN
			        return -2
	            end
	  
			  
			    Set @Varsentencia = 'Drop User [' + @UsuarioLog + ']'
                Exec (@Varsentencia)
                if(@@ERROR <> 0)
	            Begin
			         Rollback TRAN
			         return -3
	            end
	            
	            Set @Varsentencia = 'Drop Login [' + @UsuarioLog + ']'
                Exec (@Varsentencia)
                if(@@ERROR <> 0)
	            Begin
			        Rollback TRAN
			        return -4
	            end
	  
	           Commit TRAN
			   return 1
		 End
		 
      Begin TRAN		
		              
	   Delete From Usuario Where UsuarioLog = @UsuarioLog
	   if(@@ERROR <> 0)
	   Begin
			Rollback TRAN
			return -5
	   end
	   
	
	   Set @Varsentencia = 'Drop User [' + @UsuarioLog + ']'
	   if(@@ERROR <> 0)
	   Begin
	       RollBack TRAN
	       return -6
	   end
	   
	  
	   Set @Varsentencia = 'Drop Login [' + @UsuarioLog + ']'
	   if(@@ERROR <> 0)
	   Begin
	       RollBack TRAN
	       return -7
	   end
	   
	Commit TRAN
	
	return 1
End
GO


Grant exec  on ProyectoFinalSegundo.dbo.BajaUsuario TO MiRole;
GO



---------Modificar Usuario---------------------------------------------------------------------
Create Procedure ModificarUsuario @UsuarioLog varchar(20), @Contraseña varchar(10), @NombreC varchar(50) AS
Begin		
     Declare @VarSentencia varchar(200)
      
     if(Not Exists(Select * From Usuario Where UsuarioLog = @UsuarioLog AND Activo = 1))
      Begin
		   return -1
	  end
  

   if (@UsuarioLog = @UsuarioLog)
      begin
	  
	-- Multiples acciones - TRN
    Begin TRAN	
    
     Update Usuario Set Contraseña =@Contraseña,NombreC =@NombreC Where UsuarioLog = @UsuarioLog 
     If (@@ERROR <> 0)
     Begin
		   Rollback TRAN
	   	   return -2
	 end
  
  
     --primero modifico al usuario de logueo
    Set @VarSentencia = 'ALTER LOGIN[ '  + @UsuarioLog   + '] WITH PASSWORD = ' + QUOTENAME(@Contraseña, '''')
     Exec(@VarSentencia)
     If (@@ERROR <> 0)
     Begin
		   Rollback TRAN
	   	   return -3
	 end
  
   
    Commit Tran
    return 1
    
     end

else
    begin
     
      Update Usuario Set NombreC =@NombreC Where UsuarioLog = @UsuarioLog
      If (@@ERROR <> 0)
      Begin
	   	   return -4
	  end
      
    end
    
End
Go


Grant exec  on ProyectoFinalSegundo.dbo.ModificarUsuario TO MiRole;
GO



--Creo SP de busqueda Inactivo---------------------------------------------------------------------------------
Create Procedure BuscoUsuario @UsuarioLog varchar(20) AS
Begin
	Select *
	From Usuario
	where UsuarioLog = @UsuarioLog
end
go

GRANT EXECUTE ON [dbo].[BuscoUsuario] TO [IIS APPPOOL\DefaultAppPool]  
GO




---Creo Sp de buqueda Activo-----------------------------------------------------------------------------------
Create Procedure BuscoUsuarioActivo @UsuarioLog varchar(20) AS
Begin
     Select *
     From Usuario
     where UsuarioLog = @UsuarioLog AND Activo = 1
End
GO

Grant exec  on ProyectoFinalSegundo.dbo.BuscoUsuarioActivo TO MiRole;
GO



--Creo Sp de Logueo-------------------------------------------------------------------------------------
CREATE PROCEDURE LogueoUsuario @UsuarioLog varchar(20), @Contraseña varchar(20) AS
BEGIN
    select * 
    from Usuario 
    where UsuarioLog = @UsuarioLog AND Contraseña = @Contraseña AND Activo = 1
end
GO 


GRANT EXECUTE ON [dbo].[LogueoUsuario] TO [IIS APPPOOL\DefaultAppPool]   
GO


--Creo Alta Catgorias------------------------------------------------------------------------------------
Create Procedure AltaCategoria @CodigoC varchar(4),@Nombre varchar(20) AS
Begin 
	     if (Exists(Select * From Categorias Where CodigoC = @CodigoC AND Activo = 0))
			Begin
				--recordar actualizar datos no solo activar
				update Categorias
				Set Nombre = @Nombre, Activo = 1
				where CodigoC = @CodigoC
				
				return 1 --devolucion clasica, para el usuario final es lo mismo
			end
		
		-- si ya existe y esta activo -- no puedo darlo de alta (validacion de siempre)
		if(Exists(select * From Categorias where CodigoC = @CodigoC AND Activo = 1))
		Begin
		   return -1
		End   
       
        --No existe la PK - lo puedo agregar
		Insert Categorias(CodigoC, Nombre) values (@CodigoC, @Nombre)
	    if(@@ERROR <> 0)
	    Begin
	        return -2
	    End
		
End
Go

Grant exec  on ProyectoFinalSegundo.dbo.AltaCategoria TO MiRole;
GO




---Creo Baja Categorias----------------------------------------------------------------------------------
Create Procedure BajaCategorias @CodigoC varchar(4) AS
Begin 
     if(Not Exists(Select * From Categorias Where CodigoC = @CodigoC))
		Begin
			return -1
		end
			
     if(Exists(Select * From Preguntas where CodigoC = @CodigoC))
  	       Begin
		   --baja logica -- se usa update para modificar atributo de activo
		       update Categorias set Activo = 0 where CodigoC = @CodigoC
			   return 1
		   End
		                
	   Delete From Categorias Where CodigoC = @CodigoC
	   if(@@ERROR <> 0)
	   Begin
	       return -2
	   End
	   Commit
  	   return 1
End
Go


Grant exec  on ProyectoFinalSegundo.dbo.BajaCategorias TO MiRole;
GO




--Creo Sp Modificar Categorias-----------------------------------------------------------------------
Create Procedure ModificarCategorias @CodigoC varchar(4), @Nombre varchar(20) AS
Begin
     if (Not Exists(Select * From Categorias Where CodigoC = @CodigoC And Activo = 1))
			Begin
				return -1
			end
		Else
			Begin
				Update Categorias Set Nombre=@Nombre Where CodigoC = @CodigoC
				If (@@ERROR = 0)
					return 1
				Else
					return -2
			End
End
GO


Grant exec  on ProyectoFinalSegundo.dbo.ModificarCategorias TO MiRole;
GO



--Creo SP BuscoCategorias-------------------------------------------------------------------------
Create Procedure BuscoCategorias @CodigoC varchar(4) AS
Begin
	Select *
	From Categorias
	where CodigoC = @CodigoC
end
go


GRANT EXECUTE ON [dbo].[BuscoCategorias] TO [IIS APPPOOL\DefaultAppPool]  
GO



---Creo Sp de buqueda Activo-----------------------------------------------------------------------------------
Create Procedure BuscoCategoriasActivo @CodigoC varchar(4) AS
Begin
     Select *
     From Categorias
     where CodigoC = @CodigoC AND Activo = 1
End
GO



Grant exec  on ProyectoFinalSegundo.dbo.BuscoCategoriasActivo TO MiRole;   
GO


--Sp AltaJuegos----------------------------------------------------------------------------------
Create Procedure AltaJuegos @UsuarioLog varchar(20), @Dificultad varchar(10) AS
Begin                
	  IF(NOT(Exists (select * From Usuario where UsuarioLog = @UsuarioLog AND Activo = 1)))
      Begin
          return -1
      End    
      
     
	   Insert Juegos(UsuarioLog, Dificultad) Values(@UsuarioLog, @Dificultad)
	   If (@@ERROR = 0)
              return 1
	     Else
			  return -2
End
Go


Grant exec  on ProyectoFinalSegundo.dbo.AltaJuegos TO MiRole;
GO



---Creo Baja Juegos----------------------------------------------------------------------------------
Create Procedure BajaJuegos @Codigo int, @CodigoP varchar(5) AS
Begin 
         
      IF(NOT Exists(Select * From Juegos where Codigo = @Codigo))
      Begin
           return -1
      End 
      
      IF(Exists(Select * From Jugar where Codigo = @Codigo))
      Begin
          return -2
      End
      
      IF(Exists(Select * From Preguntas where CodigoP = @CodigoP))
      Begin
         return -3
      End
      
      -- Multiples acciones - TRN
      Begin TRAN	

       Delete From Juegos Where Codigo = @Codigo
	   if(@@ERROR <> 0)
	   Begin
			Rollback TRAN
			return -4
	   end
	   
	   Delete From Preguntas where CodigoP = @CodigoP
	   if(@@ERROR <> 0)
	   Begin
	        Rollback Tran
	        return -5
	   end
	    
  	   Commit TRAN
	
	  return 1
End
Go

Grant exec on ProyectoFinalSegundo.dbo.BajaJuegos TO MiRole;
GO


--Creo SP ModificarJuegos--------------------------------------------------------------------------
Create Procedure ModificarJuegos @Codigo int, @UsuarioLog varchar(20), @Dificultad varchar(10) AS
Begin
     IF(Not Exists(Select * From Juegos Where Codigo = @Codigo))
			Begin
				return -1
			end
			
	 if(Not(Exists(Select * From Usuario Where UsuarioLog = @UsuarioLog	AND Activo = 1)))
		Begin
			return -2
		end
			
		Else
			Begin
				Update Juegos Set UsuarioLog=@UsuarioLog, Dificultad = @Dificultad, FechaC = GETDATE() Where Codigo = @Codigo
				If (@@ERROR = 0)
					return 1
				Else
					return -3
			End
End
Go

Grant exec  on ProyectoFinalSegundo.dbo.ModificarJuegos TO MiRole;
GO


--Creo SP de busqueda Juegos---------------------------------------------------------------------------------
Create Procedure BuscoJuegos @Codigo int AS
Begin
	Select *
	From Juegos
	where Codigo = @Codigo
end
go


Grant exec on ProyectoFinalSegundo.dbo.BuscoJuegos TO MiRole;
GO

GRANT EXECUTE ON [dbo].[BuscoJuegos] TO [IIS APPPOOL\DefaultAppPool]   
GO 


--Sp JugarJuegos---------------------------------------------------------------------------------------------
Create Procedure JugarJuegos @Codigo int, @Nombre varchar(20), @Puntaje int AS
Begin 
         
	  IF(NOT(Exists (select * From Juegos where Codigo = @Codigo)))
      Begin
          return -1
      End    
      

	    Insert Jugar(Codigo, Nombre, Puntaje) Values(@Codigo, @Nombre,@Puntaje)
	    IF (@@ERROR<>0)
        Begin
		     return -2
	    End
	    
End
Go


GRANT EXECUTE ON [dbo].[JugarJuegos] TO [IIS APPPOOL\DefaultAppPool]   
GO 

--Sp ListadoJugadas----------------------------------------------------------------------------------
Create Procedure ListadoJugadas AS
Begin
     select *
     from Jugar
End
Go


GRANT EXECUTE ON [dbo].[ListadoJugadas] TO [IIS APPPOOL\DefaultAppPool]  
GO


--SP AltaPreguntas------------------------------------------------------------------------------------------
Create Procedure AltaPreguntas @CodigoP varchar(5), @CodigoC varchar(4), @Texto varchar(50), @Puntaje int AS
Begin

      IF(Exists(select * From Preguntas where CodigoP = @CodigoP))
      Begin
          return -1
      End
      
      
      IF(Not(Exists (select * From Categorias where CodigoC = @CodigoC AND Activo = 1)))
      Begin
          return -2
      End
    
         Insert Preguntas(CodigoP, CodigoC, Texto, Puntaje) Values(@CodigoP,@CodigoC, @Texto,@Puntaje)
	     if (@@ERROR<>0)
         Begin
		     return -3
	     End
END
Go  


Grant exec  on ProyectoFinalSegundo.dbo.AltaPreguntas TO MiRole;
GO



--Creo SP de busqueda Juegos---------------------------------------------------------------------------------
Create Procedure BuscoPreguntas @CodigoP varchar(5) AS
Begin
	Select *
	From Preguntas
	where CodigoP = @CodigoP
end
go


Grant exec  on ProyectoFinalSegundo.dbo.BuscoPreguntas TO MiRole;
GO



--Agregar Preguntas de Un Juego--------------------------------------------------------------------------
Create Procedure AltaPreguntasdeUnJuego @CodigoP varchar(5), @Codigo int AS
Begin

      IF(NOT(Exists (select * From Preguntas where CodigoP = @CodigoP)))
      Begin
          return -1
      End
      
      IF(NOT(Exists (select * From Juegos where Codigo = @Codigo)))
      Begin
          return -2
      End
      
      IF(Exists(Select * From PreguntasdeUnJuego where CodigoP = @CodigoP AND Codigo = @Codigo))
      Begin
         return -3
      End
      
      
       Insert PreguntasdeUnJuego(CodigoP, Codigo) Values(@CodigoP,@Codigo)
	   IF (@@ERROR<>0)
       Begin
     	    return -4
	   End
END
GO  

Grant exec  on ProyectoFinalSegundo.dbo.AltaPreguntasdeUnJuego TO MiRole;
GO



--Eliminar Preguntas de Un Juego--------------------------------------------------------------------------
Create Procedure EliminarPreguntasdeUnJuego @CodigoP varchar(5), @Codigo int AS
Begin

      IF(NOT Exists(Select * From PreguntasdeUnJuego where CodigoP = @CodigoP AND Codigo = @Codigo))
      Begin
         return -1
      End
      
       Delete From PreguntasdeUnJuego Where CodigoP = @CodigoP AND Codigo = @Codigo
	   IF(@@ERROR <> 0)
	   Begin
	        return -2
	   End
	    
  	   return 1

END
Go

Grant exec  on ProyectoFinalSegundo.dbo.EliminarPreguntasdeUnJuego TO MiRole;
GO


---Creo SP Alta Respuestas------------------------------------------------------------------------
Create Procedure AltaRespuestas @CodigoP varchar(5), @TextoR varchar(50), @Resultado bit AS
Begin
        
     Declare @CodigoInterno int
     
     IF(NOT(Exists(Select * From Preguntas where CodigoP = @CodigoP)))
     Begin
         return -1
     End 
         
     Select @CodigoInterno =  MAX(CodigoInterno)+1
     From Respuestas
     where CodigoP = @CodigoP 
     
     if(@CodigoInterno is null)
     select @CodigoInterno = 1

     Insert Respuestas(CodigoInterno,CodigoP,TextoR,Resultado) VALUES (@CodigoInterno,@CodigoP,@TextoR,@Resultado)
     IF(@@ERROR<>0)
     Begin
     	   return -2
     End
     
End
GO

Grant exec  on ProyectoFinalSegundo.dbo.AltaRespuestas TO MiRole;
GO



--NUEVO SP-----------------------------------------------------------------------------
--Listado PreguntasdeUnJuego------------------------------------------------------------------------------
Create Procedure ListadoPreguntasdeUnJuego @Codigo int AS
Begin
    Select *
    From Preguntas
    where CodigoP IN 
   (SELECT PreguntasdeUnJuego.CodigoP FROM PreguntasdeUnJuego 
    WHERE Codigo = @Codigo)
End
GO

GRANT EXECUTE ON [dbo].[ListadoPreguntasdeUnJuego] TO [IIS APPPOOL\DefaultAppPool] 
GO

 

--Listado JuegosConPreguntas------------------------------------------------------------------------------
Create Procedure ListadoJuegosConPreguntas AS
Begin
    Select *
    From Juegos
    where EXISTS (SELECT * FROM PreguntasdeUnJuego where Juegos.Codigo = Codigo)
End
Go


GRANT EXECUTE ON [dbo].[ListadoJuegosConPreguntas] TO [IIS APPPOOL\DefaultAppPool]  
GO




--Listados Sin Asignacion----------------------------------------------------------------------------------
Create Procedure ListadoJuegosNuncaUsados AS
Begin
     Select *
     From Juegos 
     where
      Codigo NOT IN
     (SELECT Jugar.Codigo  FROM Jugar)
END
GO


Grant exec  on ProyectoFinalSegundo.dbo.ListadoJuegosNuncaUsados TO MiRole;
GO

--Listado Preguntas NuncaUsadas
Create Procedure ListadoPreguntasNuncaUsadas AS
Begin
     Select *
     From Preguntas 
     where CodigoP NOT IN
     (SELECT PreguntasdeUnJuego.CodigoP FROM PreguntasdeUnJuego)
End
Go

Grant exec  on ProyectoFinalSegundo.dbo.ListadoPreguntasNuncaUsadas TO MiRole;
GO



--Listado Juegos Vacios
Create Procedure ListadoJuegosVacios AS
Begin
     select *
     From Juegos  
     where Codigo NOT IN
     (Select Codigo From PreguntasdeUnJuego)
End
Go

Grant exec  on ProyectoFinalSegundo.dbo.ListadoJuegosVacios TO MiRole;
GO



--Listado RespuestasdeUnaPregunta
Create Procedure ListadoRespuestasdeUnaPregunta @CodigoP varchar(5) AS
Begin
     select *
     From Respuestas 
     Where CodigoP = @CodigoP
End 
GO


GRANT EXECUTE ON [dbo].[ListadoRespuestasdeUnaPregunta] TO [IIS APPPOOL\DefaultAppPool]  
GO

--------------------------------------------------------------------------------------------------------------------------
--datos de prueba

--Usuario
exec AltaUsuario 'rodrigoc','abcde1','rodrigocardelus'
exec AltaUsuario 'camilaca','vegan5', 'camilacardelus'
exec AltaUsuario 'mathiase','eeeee4', 'mathiasestevez'
exec AltaUsuario 'facundor','trist1', 'facundoromero'
exec AltaUsuario 'estelagr','feliz1', 'estelagrenni'
go



exec AltaJuegos 'rodrigoc', 'FACIL'
exec AltaJuegos 'camilaca', 'MEDIO'
exec AltaJuegos 'mathiase', 'DIFICIL'
exec AltaJuegos 'facundor', 'MEDIO'
exec AltaJuegos 'estelagr', 'DIFICIL'
Go

select * from Juegos


Exec JugarJuegos 1, 'rodrigoc', 10
go
Exec JugarJuegos 2,'camilaca', 7
go
Exec JugarJuegos 3, 'mathiase', 9
go
Exec JugarJuegos 4, 'facundor', 6
go



Exec AltaCategoria 'GEOG', 'Geografia'
Exec AltaCategoria 'HIST', 'Historia'
Exec AltaCategoria 'DERE', 'Derecho'
Exec AltaCategoria 'LITE', 'Literatura'
Exec AltaCategoria 'FILO', 'Filosofia'
Exec AltaCategoria 'ECON', 'Economia'
Exec AltaCategoria 'INFO', 'Informatica'
go




Exec AltaPreguntas 'g1g1g','GEOG','Cuantos Continentes Hay',10
Exec AltaPreguntas 'g2g2g','HIST', 'En que año se descubrio America',6
Exec AltaPreguntas 'h2h2h','HIST', 'Cual es el año de la Caida del Muro de Berlin',6
Exec AltaPreguntas 'h3h3h','LITE', 'Que libros de estos son de Edgar Allan Poe',7
Exec AltaPreguntas 'n4n4n','DERE', 'Como se dividen los Poderes en Uruguay',4
/*
Exec AltaPreguntas 'ff6f6','FILO', 'Quien era el alumno de Socrates', 3
Exec AltaPreguntas 'e7e7e','ECON', 'Como se llama el grupo que forman las Economias Emergentes ', 8
Exec AltaPreguntas '88ii8','INFO', 'Cuanto ocupa un terabyte', 10
Exec AltaPreguntas '88ii8','INFO', 'Quien es el Creador de Linux', 6*/

GO


Exec AltaPreguntasdeUnJuego 'g1g1g', 1
Exec AltaPreguntasdeUnJuego 'g2g2g', 1
Exec AltaPreguntasdeUnJuego 'h2h2h', 3
Exec AltaPreguntasdeUnJuego 'h3h3h', 4

/*
Exec AltaPreguntasdeUnJuego 'n4n4n', 5
Exec AltaPreguntasdeUnJuego 'n4n4n', 6
Exec AltaPreguntasdeUnJuego 'ff6f6', 7
Exec AltaPreguntasdeUnJuego 'e7e7e', 8
Exec AltaPreguntasdeUnJuego '88ii8', 9
Exec AltaPreguntasdeUnJuego '88ii8', 10*/
go



Exec AltaRespuestas 'g1g1g', '1', 'False'
Exec AltaRespuestas 'g1g1g', '7', 'True'
Exec AltaRespuestas 'g1g1g', '4', 'False'
Exec AltaRespuestas 'g2g2g', '1492', 'True'
Exec AltaRespuestas 'g2g2g', '1600', 'False'
Exec AltaRespuestas 'g2g2g', '1592', 'False'
Exec AltaRespuestas 'h2h2h', '1989', 'True'
Exec AltaRespuestas 'h2h2h', '1993', 'False'
Exec AltaRespuestas 'h2h2h', '1980', 'False'
/*Exec AltaRespuestas 'h3h3h', 'Don Quijote de la Mancha', 'False'
Exec AltaRespuestas 'h3h3h', 'El Gato Negro', 'True'
Exec AltaRespuestas 'h3h3h',  'El Lazarillo de Tormes', 'False'
*/
Exec AltaRespuestas 'n4n4n', 'Don Quijote de la Mancha', 'False'
Exec AltaRespuestas 'n4n4n', 'El Gato Negro', 'True'
Exec AltaRespuestas 'n4n4n', 'El Lazarillo de Tormes', 'False'
Exec AltaRespuestas 'd5d5d', 'Poder Ejecutivo y  Legislativo', 'False'
Exec AltaRespuestas 'd5d5d', 'Poder Legislativo', 'False'
Exec AltaRespuestas 'd5d5d', 'Poder Ejecutivo,Legislativo y Judicial', 'True'
Exec AltaRespuestas 'ff6f6', 'Aristoteles', 'False'
Exec AltaRespuestas 'ff6f6', 'Platon', 'True'
Exec AltaRespuestas 'ff6f6', 'Pitagoras', 'False'
Exec AltaRespuestas 'e7e7e', 'E7', 'True'
Exec AltaRespuestas 'e7e7e', 'G7', 'False'
Exec AltaRespuestas 'e7e7e', 'G20', 'False'
Exec AltaRespuestas '88ii8', '100GB', 'False'
Exec AltaRespuestas '88ii8', '1000GB', 'True'
Exec AltaRespuestas '88ii8', '10GB', 'False'
Exec AltaRespuestas '88ii8', 'Bill Gates', 'False'
Exec AltaRespuestas '88ii8', 'Elon Musk', 'False'
Exec AltaRespuestas '88ii8', 'Linus Torvalds', 'True'
go


exec ListadoJugadas
go

exec ListadoJuegosNuncaUsados
Go


exec ListadoPreguntasNuncaUsadas 
go

exec ListadoJuegosVacios
go


select * 
from Usuario

select *
from Juegos

select *
from Preguntas

select *
from PreguntasdeUnJuego

select *
from Respuestas


select *
from Categorias

select *
from Jugar


exec ListadoRespuestasdeUnaPregunta '4n4n4'
go

exec ListadoPreguntasNuncaUsadas
go

exec ModificarJuegos 3, 'mathiase', 'FACIL'
GO

/*
declare @VarSentencia varchar(200)
declare @UsuarioLog varchar(20)

set @UsuarioLog='rodrigoc'


/*set @VarSentencia = 'use master';
Exec(@VarSentencia)*/
Set @VarSentencia = 'use master; Grant ALTER ANY LOGIN TO ' +  @UsuarioLog;
Exec(@VarSentencia)

drop login canilaca*/