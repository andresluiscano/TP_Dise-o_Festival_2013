--AGREGO UN FESTIVAL
INSERT INTO Festival (id_festival,anio_ed, dto_vta_anticip,dia_fest, f_inicio, pje_dev_por_anul) 
VALUES (1,1,15,5,GETDATE(),15 );

--AGREGO LOS DIAS PARA EL FESTIVAL
INSERT INTO DiaFestival (id_dia, fecha, precio_entr, fecha_vto_anul_entr, id_festival) 
VALUES (11,GETDATE(),150 , GETDATE()+10, 1);
INSERT INTO DiaFestival (id_dia, fecha, precio_entr, fecha_vto_anul_entr, id_festival) 
VALUES (12,GETDATE()+1,100 , GETDATE()+10, 1);
INSERT INTO DiaFestival (id_dia, fecha, precio_entr, fecha_vto_anul_entr, id_festival) 
VALUES (13,GETDATE()+2,200 , GETDATE()+10, 1);
INSERT INTO DiaFestival (id_dia, fecha, precio_entr, fecha_vto_anul_entr, id_festival) 
VALUES (14,GETDATE()+2,250 , GETDATE()+10, 1);
INSERT INTO DiaFestival (id_dia, fecha, precio_entr, fecha_vto_anul_entr, id_festival) 
VALUES (15,GETDATE()+2,300, GETDATE()+10, 1);


--AGREGO BANDAS PARA EL DIA 1 DEL FESTIVAL 1

INSERT INTO GrupoMusical (id_grupo,nombre, cant_integrantes, id_dia) 
VALUES (1, 'PinkFloyd', 5, 11)

INSERT INTO GrupoMusical (id_grupo,nombre, cant_integrantes, id_dia) 
VALUES (2, 'Queen', 4, 11)

INSERT INTO GrupoMusical (id_grupo,nombre, cant_integrantes, id_dia) 
VALUES (3, 'Metallica', 5, 11)

INSERT INTO GrupoMusical (id_grupo,nombre, cant_integrantes, id_dia) 
VALUES (4, 'Los Autenticos Decadente', 88, 11)

INSERT INTO GrupoMusical (id_grupo,nombre, cant_integrantes, id_dia) 
VALUES (5, 'Kapanga', 88, 11)

--Insert TipoEntrada
INSERT INTO TipoEntrada(id_tipo_entrada,descripcion) 
VALUES (1,'JUBILADO')

INSERT INTO TipoEntrada(id_tipo_entrada,descripcion) 
VALUES (2,'MENOR')

INSERT INTO TipoEntrada(id_tipo_entrada,descripcion) 
VALUES (3,'ADULTO')

--Insert PrecioEntrada
INSERT INTO PrecioEntrada(id_precio,precio,tipo_entrada,id_entrada,id_dia,id_tipo_entrada) 
VALUES (1,100,1,1,12,1)

INSERT INTO PrecioEntrada(id_precio,precio,tipo_entrada,id_entrada,id_dia,id_tipo_entrada) 
VALUES (2,100,2,1,13,2)

INSERT INTO PrecioEntrada(id_precio,precio,tipo_entrada,id_entrada,id_dia,id_tipo_entrada) 
VALUES (3,100,3,1,14,3)

--Insert ButacaPrecio
INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (1,'A1',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (2,'A2',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (3,'A3',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (4,'A4',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (5,'A5',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (6,'A6',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (7,'A7',1,0)

INSERT INTO ButacaPrecio(id_butaca_sector,sector,id_precio,disponible) 
VALUES (8,'A8',1,0)

