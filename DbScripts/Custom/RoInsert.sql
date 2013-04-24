-- RoleRo
INSERT INTO "RoleRo" ("Code", "Name", "RoleId")
	VALUES('Admin', 'Admin', 1);

INSERT INTO "RoleRo" ("Code", "Name", "RoleId")
	VALUES('User', 'User', 2);
	
-- AuditInfoActionTypeRo
INSERT INTO "AuditInfoActionTypeRo" ("Code", "Name", "AuditInfoActionTypeId")
	VALUES('Insert', 'Insert', 1);
	
INSERT INTO "AuditInfoActionTypeRo" ("Code", "Name", "AuditInfoActionTypeId")
	VALUES('Update', 'Update', 2);
	
INSERT INTO "AuditInfoActionTypeRo" ("Code", "Name", "AuditInfoActionTypeId")
	VALUES('Delete', 'Delete', 3);
	
-- EntityRo
INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('AuditInfo', 'AuditInfo', 1);
	
INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('TrgovanjeGlava', 'TrgovanjeGlava', 3);
	
INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('TrgovanjeStavka', 'TrgovanjeStavka', 4);

INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('User', 'User', 5);

INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('RepoAukcija', 'RepoAukcija', 6);	

INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('Sudionik', 'Sudionik', 7);
	
INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('TrgovanjeGlavaHnb', 'TrgovanjeGlavaHnb', 8);
	
INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('TrgovanjeStavkaHnb', 'TrgovanjeStavkaHnb', 9);

INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('HtmlPage', 'HtmlPage', 10);

INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('KamatnaStopaHnb', 'KamatnaStopaHnb', 11);

INSERT INTO "EntityRo" ("Code", "Name", "EntityId")
	VALUES('ZakljuceniMjesec', 'ZakljuceniMjesec', 12);
	
-- ValutaRo
INSERT INTO "ValutaRo" ("Code", "Name", "ValutaId", "SifraSlog")
	VALUES('Kn', 'Kuna', 1, 'KN');

INSERT INTO "ValutaRo" ("Code", "Name", "ValutaId", "SifraSlog")
	VALUES('Chf', 'Švicarski franak', 2, 'CHF');

INSERT INTO "ValutaRo" ("Code", "Name", "ValutaId", "SifraSlog")
	VALUES('Eur', 'Euro', 3, 'EUR');

INSERT INTO "ValutaRo" ("Code", "Name", "ValutaId", "SifraSlog")
	VALUES('Usd', 'Amerièki dolar', 4, 'USD');

-- TrgovanjeVrstaRo
INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('Opoziv', 'Opoziv', 1, 'OPO');

INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('TomNext', 'TOM/NEXT', 2, 'T/N');
	
INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('SpotNext', 'SPOT/NEXT', 3, 'S/N');

INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('RocniDepozit', 'Roèni depozit', 4, '2-6');
	
INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('JedanTjedan', '1 tjedan', 5, '1TJ');

INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('DvaTjedna', '2 tjedna', 6, '2TJ');
	
INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('JedanMjesec', '1 mjesec', 7, '1MJ');
	
INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('TriMjeseca', '3 mjeseca', 8, '3MJ');
	
INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('ViseOdTriMjeseca', 'više od tri mjeseca', 9, '3M+');

INSERT INTO "TrgovanjeVrstaRo" ("Code", "Name", "TrgovanjeVrstaId", "SifraSlog")
	VALUES('Prekonocni', 'prekonoæni', 10, 'O/N');

-- SudionikGrupaRo
INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('Dionicari', 'Dionièari', 1);

INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('KorisneAdrese', 'Korisne adrese', 2);

INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('Banke', 'Banke', 3);
	
INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('InvesticijskiFondovi', 'Društva za upravljanje investicijskim fondovima', 4);
	
INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('MirovinskiFondovi', 'Društva za upravljanje mirovinskim fondovima', 5);

INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('OsiguravajucaDrustva', 'Osiguravajuæa društva', 6);

INSERT INTO "SudionikGrupaRo" ("Code", "Name", "SudionikGrupaId")
	VALUES('StambeneStedionice', 'Stambene štedionice', 7);

-- SistemskaInstancaPodataka
INSERT INTO "SistemskaInstancaPodatakaRo" ("Code", "Name", "SistemskaInstancaPodatakaId")
	VALUES('HtmlONamaHr', 'O nama HR verzija', 1);

INSERT INTO "SistemskaInstancaPodatakaRo" ("Code", "Name", "SistemskaInstancaPodatakaId")
	VALUES('HtmlONamaEn', 'O nama EN verzija', 2);

INSERT INTO "SistemskaInstancaPodatakaRo" ("Code", "Name", "SistemskaInstancaPodatakaId")
	VALUES('HtmlSett', 'Sustav SETT', 3);

INSERT INTO "SistemskaInstancaPodatakaRo" ("Code", "Name", "SistemskaInstancaPodatakaId")
	VALUES('HtmlKontakt', 'Kontakt', 4);