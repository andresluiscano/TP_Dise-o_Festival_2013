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
VALUES (4, 'Los Autenticos Decadente', 88, 11)

