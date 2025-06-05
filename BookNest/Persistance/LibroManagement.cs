using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace MyReads.Persistance
{
    internal class LibroManagement
    {
        private List<Libro> listLibro { get; set; }
        private DataTable table { get; set; }
        public LibroManagement()
        {
            table = new DataTable();
        }
        public List<Libro> ListLibro { get { return listLibro; } set { listLibro = value; } }

        public Libro readLibro(int id)
        {
            Libro u = null;
            List<Object> lLibro;
            lLibro = DBBroker.obtenerAgente().leer("SELECT * FROM libro WHERE idLibro=" + id + ";");
            foreach (List<Object> aux in lLibro)
            {
                u = new Libro(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setAutor(aux[2].ToString());
                u.setSinopsis(aux[3].ToString());
                u.setEditorial(aux[4].ToString());
                u.setPags(Int32.Parse(aux[5].ToString()));
                u.setYear(Int32.Parse(aux[6].ToString()));
                u.setImg(aux[7].ToString());
                u.setIdGenero(Int32.Parse(aux[8].ToString()));
            }
            return u;
        }
        public Libro readLibroByNombre(String titulo)
        {
            Libro u = null;
            List<Object> lLibro;
            lLibro = DBBroker.obtenerAgente().leer("SELECT * FROM libro WHERE titulo='" + titulo+ "';");
            foreach (List<Object> aux in lLibro)
            {
                u = new Libro(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setAutor(aux[2].ToString());
                u.setSinopsis(aux[3].ToString());
                u.setEditorial(aux[4].ToString());
                u.setPags(Int32.Parse(aux[5].ToString()));
                u.setYear(Int32.Parse(aux[6].ToString()));
                u.setImg(aux[7].ToString());
                u.setIdGenero(Int32.Parse(aux[8].ToString()));
            }
            return u;
        }
        public List<Libro> readAll()
        {
            List<Libro> list=new List<Libro>();
            Libro u;
            List<Object> lLibro;
            lLibro = DBBroker.obtenerAgente().leer("SELECT * FROM libro;");
            foreach (List<Object> aux in lLibro)
            {
                u = new Libro(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setAutor(aux[2].ToString());
                u.setSinopsis(aux[3].ToString());
                u.setEditorial(aux[4].ToString());
                u.setPags(Int32.Parse(aux[5].ToString()));
                u.setYear(Int32.Parse(aux[6].ToString()));
                u.setImg(aux[7].ToString());
                u.setIdGenero(Int32.Parse(aux[8].ToString()));
                list.Add(u);
            }
            return list;
        }
        public List<Libro> readByGenero(String nombre)
        {
            List<Libro> list = new List<Libro>();
            Libro u;
            List<Object> lLibro;
            lLibro = DBBroker.obtenerAgente().leer("SELECT * FROM libro WHERE Genero_idGenero = (SELECT idGenero FROM genero WHERE nombre = '"+nombre+"'); ");
            foreach (List<Object> aux in lLibro)
            {
                u = new Libro(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setAutor(aux[2].ToString());
                u.setSinopsis(aux[3].ToString());
                u.setEditorial(aux[4].ToString());
                u.setPags(Int32.Parse(aux[5].ToString()));
                u.setYear(Int32.Parse(aux[6].ToString()));
                u.setImg(aux[7].ToString());
                u.setIdGenero(Int32.Parse(aux[8].ToString()));
                list.Add(u);
            }
            return list;
        }
        public void insertLibro(Libro u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into libro(titulo,autor,sinopsis,editorial,pags,publicacion,img,Genero_idGenero) values ('" + u.titulo + "','" + u.autor+ "','"+u.sinopsis+"','"+u.editorial+"',"+u.numPags+","+u.year+","+u.img+","+u.idGenero+");");
        }
        public void deleteLibro(Libro u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from libro where idLibro=" + u.getId() + ";");
        }



        public void insertarLibroColeccion(Libro l, Coleccion c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into libroscoleccion(Coleccion_idColeccion,Libro_idLibro) values (" +c.idColeccion+","+l.idLibro+");");
        }
        public void deleteLibroColeccion(Libro l, Coleccion c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from libroscoleccion WHERE Libro_idLibro="+l.idLibro+" AND Coleccion_idColeccion="+c.idColeccion+";");
        }
        public List<Libro> leerLibrosColeccion(Coleccion c)
        {
            List<Libro> list = new List<Libro>();
            Libro u;
            List<Object> lLibro;
            lLibro = DBBroker.obtenerAgente().leer("SELECT* FROM libro WHERE idLibro IN(SELECT Libro_idLibro FROM libroscoleccion WHERE Coleccion_idColeccion = " + c.idColeccion + ");");
            foreach (List<Object> aux in lLibro)
            {
                u = new Libro(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setAutor(aux[2].ToString());
                u.setSinopsis(aux[3].ToString());
                u.setEditorial(aux[4].ToString());
                u.setPags(Int32.Parse(aux[5].ToString()));
                u.setYear(Int32.Parse(aux[6].ToString()));
                u.setImg(aux[7].ToString());
                u.setIdGenero(Int32.Parse(aux[8].ToString()));
                list.Add(u);
            }
            return list;
        }
        

        public void generarLibros()
        {
            List<Libro> lista = new List<Libro>();
            //FANTASIA
            lista.Add(new Libro("El Nombre del Viento","Patrick Rothfuss","La historia de Kvothe,un joven con un talento excepcional para la magia y la música,que se convierte en una leyenda en su mundo.","Plaza & Janés",880,2007,1, "el_nombre_del_viento.jpg"));
            lista.Add(new Libro("El temor de un hombre sabio","Patrick Rothfuss","Segunda parte de El Nombre del Viento,sigue la vida de Kvothe mientras enfrenta nuevos desafíos y se adentra en misterios aún más profundos.","Plaza & Janés",1190,2011,1, "el_temor_de_un_hombre_sabio.jpg"));
            lista.Add(new Libro("El estrecho sendero entre deseos","Patrick Rothfuss","Una novela corta centrada en Bast,el misterioso compañero de Kvothe,que explora su astucia y habilidades mágicas.","Subterranean Press",176,2014,1,"el_estrecho_sendero_entre_deseos.jpg"));
            lista.Add(new Libro("La música del silencio","Patrick Rothfuss","Una novela sobre Auri,un personaje entrañable de la saga,que ofrece una visión introspectiva de su mundo.","Plaza & Janés",160,2014,1, "la_musica_del_silencio.jpg"));
            lista.Add(new Libro("El árbol del relámpago","Patrick Rothfuss","Una novela corta sobre Bast,que ahonda en su vida y en sus habilidades para la manipulación y el engaño.","Subterranean Press",144,2014,1, "el_arbol_del_relampago.jpg"));
            lista.Add(new Libro("El camino de los reyes","Brandon Sanderson","Primera entrega de El Archivo de las Tormentas,una épica historia de guerreros,magia y profecías en un mundo asolado por tormentas sobrenaturales.","Nova",1216,2010,1, "el_camino_de_los_reyes.jpg"));
            lista.Add(new Libro("Palabras radiantes","Brandon Sanderson","Segunda parte de El Archivo de las Tormentas,en la que los personajes continúan su evolución en un mundo lleno de conspiraciones y magia.","Nova",1328,2014,1, "palabras_radiantes.jpg"));
            lista.Add(new Libro("Juramentada","Brandon Sanderson","Tercera entrega de la saga,que profundiza en los secretos del mundo de Roshar y en la batalla entre la humanidad y los Portadores del Vacío.","Nova",1248,2017,1, "juramentada.jpg"));
            lista.Add(new Libro("El ritmo de la guerra","Brandon Sanderson","Cuarta entrega de El Archivo de las Tormentas,que sigue la guerra de los humanos contra los Fusionados y revela más sobre los enigmas del mundo de Roshar.","Nova",1376,2020,1, "el_ritmo_de_la_guerra.jpg"));
            lista.Add(new Libro("Viento y verdad","Brandon Sanderson","Próxima entrega de El Archivo de las Tormentas,aún por publicar.","Nova",1500,2025,1, "viento_y_verdad.jpg"));
            lista.Add(new Libro("El imperio final","Brandon Sanderson","Primera parte de la trilogía Nacidos de la Bruma,en la que un grupo de rebeldes intenta derrocar a un imperio gobernado por el Lord Legislador.","Nova",672,2006,1, "el_imperio_final.jpg"));
            lista.Add(new Libro("El pozo de la ascensión","Brandon Sanderson","Segunda parte de la trilogía Nacidos de la Bruma,que explora las consecuencias del derrocamiento del Lord Legislador y los secretos de la magia alomántica.","Nova",800,2007,1, "el_pozo_de_la_ascension.jpg"));
            lista.Add(new Libro("El héroe de las eras","Brandon Sanderson","Conclusión de la trilogía original de Nacidos de la Bruma,en la que Vin y sus aliados luchan contra una fuerza que amenaza con destruir el mundo.","Nova",800,2008,1, "el_heroe_de_las_eras.jpg"));
            lista.Add(new Libro("Aleación de ley","Brandon Sanderson","Una novela ambientada en el mismo mundo de Nacidos de la Bruma,pero varios años después,con un enfoque en los avances de la sociedad y la tecnología.","Nova",544,2011,1, "aleacion_de_ley.jpg"));
            lista.Add(new Libro("Sombras de identidad","Brandon Sanderson","Primera entrega de la serie Nacidos de la bruma era 2,donde un detective debe resolver un misterio en un mundo de magia y política.","Nova",592,2014,1, "sombras_de_identidad.jpg"));
            lista.Add(new Libro("Brazales de duelo","Brandon Sanderson","Una historia de acción y magia que sigue los conflictos de los personajes de la serie Nacidos de la bruma era 2.","Nova",400,2016,1, "brazales_de_duelo.jpg"));
            lista.Add(new Libro("El metal perdido","Brandon Sanderson","El final de la saga Nacidos de la Bruma era 2,que une todos los misterios y conflictos en una última lucha para salvar el mundo.","Nova",544,2019,1, "el_metal_perdido.jpg"));
            lista.Add(new Libro("El aliento de los dioses","Brandon Sanderson","Un mundo donde las personas pueden regalar su aliento para obtener poderes mágicos. La lucha por el control de estos poderes es el eje central.","Nova",576,2009,1, "el_aliento_de_los_dioses.jpg"));
            lista.Add(new Libro("Elantris","Brandon Sanderson","El primer libro de Sanderson,que sigue la historia de Elantris,una ciudad de dioses caídos y los misterios que la rodean.","Nova",592,2005,1, "elantris.jpg"));
            lista.Add(new Libro("Arcanum Ilimitada","Brandon Sanderson","Una colección de relatos cortos que exploran diferentes mundos y personajes de las sagas de Sanderson.","Nova",672,2016,1, "arcanum_ilimitado.jpg"));
            lista.Add(new Libro("Trenza del mar esmeralda","Brandon Sanderson","Una novela de fantasía que sigue el viaje de una joven que se embarca en una aventura a través de mares llenos de secretos.","Nova",576,2019,1, "trenza_del_mar_esmeralda.jpg"));
            lista.Add(new Libro("Yumi y el pintor de pesadillas","Brandon Sanderson","Una historia de aventuras con una protagonista que debe enfrentarse a una amenaza misteriosa que afecta su pueblo.","Nova",432,2021,1, "yumi_y_el_pintor_de_pesadillas.jpg"));
            lista.Add(new Libro("El hombre iluminado","Brandon Sanderson","Una novela de fantasía que mezcla magia,misterio y acción,siguiendo a un protagonista en su búsqueda de respuestas sobre su pasado.","Nova",500,2022,1, "el_hombre_iluminado.jpg"));
            lista.Add(new Libro("Aprendiz de asesino","Robin Hobb","La historia de FitzChivalry,un joven que es entrenado como asesino en un mundo de magia y política.","Ediciones B",432,1995,1, "aprendiz_de_asesino.jpg"));
            lista.Add(new Libro("Asesino Real","Robin Hobb","Segunda parte de la saga El asesino real,en la que FitzChivalry se enfrenta a nuevos desafíos y secretos oscuros.","Ediciones B",464,1997,1, "asesino_real.jpg"));
            lista.Add(new Libro("La búsqueda del asesino","Robin Hobb","FitzChivalry continúa su entrenamiento como asesino mientras enfrenta conspiraciones y traiciones en su camino.","Ediciones B",496,1998,1, "la_busqueda_del_asesino.jpg"));
            lista.Add(new Libro("Las naves de la magia","Robin Hobb","Un viaje hacia nuevas tierras donde los protagonistas se enfrentan a viejas enemistades y misterios sin resolver.","Ediciones B",528,2000,1, "las_naves_de_la_magia.jpg"));
            lista.Add(new Libro("Las naves de la locura","Robin Hobb","Las aventuras de los personajes en un mundo lleno de magia,secretos y luchas políticas.","Ediciones B",576,2001,1, "las_naves_de_la_locura.jpg"));
            lista.Add(new Libro("Las naves del destino","Robin Hobb","La última parte de la saga,donde los personajes deben decidir el futuro de un mundo en ruinas.","Ediciones B",512,2002,1, "las_naves_del_destino.jpg"));
            lista.Add(new Libro("La suerte del bufón","Robin Hobb","Un relato que sigue la vida del Bufón,uno de los personajes más complejos de la saga,con temas de magia y destino.","Ediciones B",560,2004,1, "la_suerte_del_bufon.jpg"));
            lista.Add(new Libro("La voz de las espadas","Joe Abercrombie","Un oscuro relato de guerra,política y magia,en un mundo brutal donde los personajes deben luchar por sobrevivir.","Ediciones B",432,2006,1, "la_voz_de_las_espadas.jpg"));
            lista.Add(new Libro("Antes de que nos cuelguen","Joe Abercrombie","Continuación de la historia de los personajes en un mundo violento y lleno de traiciones,donde las lealtades están siempre en juego.","Ediciones B",448,2007,1, " antes_de_que_nos_cuelguen.jpg"));
            lista.Add(new Libro("El último argumento de los reyes","Joe Abercrombie","El desenlace de la trilogía que explora la guerra,la política y las decisiones difíciles en un mundo desolado y brutal.","Ediciones B",528,2008,1, "el_ultimo_argumento_de_los_reyes.jpg"));
            lista.Add(new Libro("Juego de tronos","George R.R. Martin","La primera novela de la épica saga Canción de hielo y fuego,donde las casas nobles luchan por el control del trono de hierro.","Editorial Gigamesh",800,1996,1, "juego_de_tronos.jpg"));
            lista.Add(new Libro("Choque de reyes","George R.R. Martin","Segunda parte de la saga,con más intrigas políticas y batallas,mientras las casas luchan por el poder.","Editorial Gigamesh",784,1998,1, "choque_de_reyes.jpg"));
            lista.Add(new Libro("Tormenta de espadas","George R.R. Martin","La tercera parte de la saga,donde las traiciones y las alianzas deciden el futuro de Westeros en una guerra sin cuartel.","Editorial Gigamesh",976,2000,1, "tormenta_de_espadas.jpg"));
            lista.Add(new Libro("Festín de cuervos","George R.R. Martin","Cuarta entrega de la serie,centrada en las consecuencias de la guerra y los nuevos personajes que emergen en la lucha por el poder.","Editorial Gigamesh",896,2005,1, "festin_de_cuervos.jpg"));
            lista.Add(new Libro("Danza de dragones","George R.R. Martin","Quinta parte de la saga,donde los destinos de los personajes continúan en su lucha por el control del trono en un mundo lleno de dragones y magia.","Editorial Gigamesh",1040,2011,1, "danza_de_dragones.jpg"));
            //CIENCIA FICCION
            lista.Add(new Libro("Amanecer Rojo","Pierce Brown","En un futuro distópico,Darrow,un joven nacido en la opresión,lucha para derrocar un sistema de castas que divide a la sociedad.","Minotauro",384,2014,4, "amanecer_rojo.jpg"));
            lista.Add(new Libro("Hijo dorado","Pierce Brown","Segunda entrega de la saga Amanecer Rojo,donde Darrow sigue luchando en la guerra para derribar el sistema opresivo.","Minotauro",512,2015,4, "hijo_dorado.png"));
            lista.Add(new Libro("Mañana azul","Pierce Brown","Tercera parte de la serie,en la que Darrow continúa su lucha mientras enfrenta decisiones que cambiarán el curso de la historia.","Minotauro",592,2016,4, "manana_azul.jpg"));
            lista.Add(new Libro("Oro y Ceniza","Pierce Brown","La cuarta entrega de la saga,donde Darrow debe enfrentarse a nuevas amenazas mientras la guerra se intensifica.","Minotauro",624,2019,4, "oro_y_ceniza.jpg"));
            lista.Add(new Libro("Edad oscura","Pierce Brown","La quinta entrega de la saga,llena de giros inesperados y luchas por la supervivencia en un mundo fracturado.","Minotauro",752,2020,4, "edad_oscura.jpg"));
            lista.Add(new Libro("Proyecto Hail Mary","Andy Weir","Un astronauta despierta sin recuerdos y debe salvar a la humanidad de un desastre cósmico.","Alianza Editorial",496,2021,4, " proyecto_hail_mary.jpg"));
            lista.Add(new Libro("El problema de los tres cuerpos","Cixin Liu","En una China gobernada por el caos,un grupo de científicos lucha por resolver el misterio de una civilización alienígena que amenaza la Tierra.","Editorial Edhasa",560,2008,4, "el_problema_de_los_tres_cuerpos.jpg"));
            lista.Add(new Libro("El bosque oscuro","Cixin Liu","Segunda parte de la trilogía,donde la humanidad enfrenta la inminente llegada de los alienígenas en una guerra intergaláctica.","Editorial Edhasa",592,2008,4, "el_bosque_oscuro.jpg"));
            lista.Add(new Libro("El fin de la muerte","Cixin Liu","La conclusión de la trilogía,en la que la humanidad lucha por su supervivencia mientras explora conceptos avanzados de física y tecnología.","Editorial Edhasa",640,2010,4, "el_fin_de_la_muerte.jpg"));
            lista.Add(new Libro("Hyperion","Dan Simmons","En un futuro lejano,siete peregrinos viajan hacia el planeta Hyperion,cada uno con una historia que revela secretos del universo.","Ediciones B",544,1989,4, "hyperion.jpg"));
            lista.Add(new Libro("Empire of Silence","Christopher Ruocchio","Un hombre condenado por un crimen que no cometió,lucha por entender el destino que lo ha llevado a ser parte de una guerra galáctica.","Editorial Minotauro",544,2018,4, "empire_of_silence.jpg"));
            lista.Add(new Libro("Dune","Frank Herbert","En un futuro lejano,Paul Atreides se convierte en el líder de un imperio galáctico en un planeta desértico,enfrentando guerras y traiciones.","Editorial Planeta",688,1965,4, "dune.jpg"));
            lista.Add(new Libro("El mesías de Dune","Frank Herbert","Segunda parte de la saga Dune,donde Paul Atreides enfrenta las consecuencias de su ascensión al poder y su destino.","Editorial Planeta",400,1969,4, " el_mesias_de_dune.jpg"));
            lista.Add(new Libro("Los hijos de Dune","Frank Herbert","Tercera parte de la saga,donde los hijos de Paul Atreides enfrentan nuevos retos para preservar el legado de su padre.","Editorial Planeta",496,1976,4, "los_hijos_de_dune.jpg"));
            lista.Add(new Libro("Dios Emperador de Dune","Frank Herbert","Cuarta entrega de la saga,en la que el hijo de Paul Atreides se convierte en un ser inmortal y busca cambiar el destino de la humanidad.","Editorial Planeta",464,1981,4, "dios_emperador_de_dune.jpg"));
            lista.Add(new Libro("Herejes de Dune","Frank Herbert","Quinta entrega de la saga,donde los descendientes de los Atreides deben luchar contra las fuerzas externas que amenazan con destruir el equilibrio de su imperio.","Editorial Planeta",448,1984,4, "herejes_de_dune.jpg"));
            lista.Add(new Libro("Casa Capitular Dune","Frank Herbert","Última parte de la serie original,en la que la lucha por el control del planeta Dune alcanza su punto máximo.","Editorial Planeta",448,1985,4, "casa_capitular_dune.jpg"));
            //,""
            lista.Add(new Libro("La caída de los gigantes","Ken Follett","La historia de varias familias cuyas vidas se ven entrelazadas por los eventos de la Primera Guerra Mundial.","Editorial Planeta",960,2010,5, "la_caida_de_los_gigantes.jpg"));
            lista.Add(new Libro("El invierno del mundo","Ken Follett","Segunda parte de la trilogía The Century,que narra la historia de la Segunda Guerra Mundial y sus repercusiones.","Editorial Planeta",960,2012,5, "el_invierno_del_mundo.jpg"));
            lista.Add(new Libro("Guerra y paz","Leo Tolstoy","Una de las novelas más importantes de la literatura rusa,que explora la vida de las familias nobles durante las Guerras Napoleónicas.","Editorial Espasa",1500,1869,5, "guerra_y_paz.jpg"));
            lista.Add(new Libro("El juez de Egipto","Christian Jacq","La historia de Ramsés II,uno de los faraones más famosos de Egipto,y su lucha por preservar el imperio.","Ediciones B",672,1995,5, "el_juez_de_egipto.jpg"));
            lista.Add(new Libro("Shogun","James Clavell","Un británico naufraga en Japón en el siglo XVII,donde se ve involucrado en las intrigas políticas y la cultura del país.","Ediciones B",1168,1975,5, "shogun.jpg"));
            lista.Add(new Libro("Tai-pan","James Clavell","La historia de la fundación de Hong Kong y el conflicto entre comerciantes británicos y chinos en el siglo XIX.","Ediciones B",800,1990,5, "tai_pan.jpg"));
            lista.Add(new Libro("Gai-jin","James Clavell","Secuela de Shogun,que sigue la historia de los descendientes de los personajes originales en el Japón del siglo XIX.","Ediciones B",752,1993,5, " gai_jin.jpg"));
            lista.Add(new Libro("La guerra civil española","Hugh Thomas","Un análisis detallado de la guerra civil española,sus causas y consecuencias,con un enfoque histórico y político.","Ediciones Taurus",1344,1961,5, "la_guerra_civil_espanola.jpg"));
            lista.Add(new Libro("Los miserables","Victor Hugo","Una novela sobre la lucha de la justicia y la redención en la Francia post-revolucionaria,centrada en personajes como Jean Valjean y Javert.","Penguin Classics",1600,1862,5, "los_miserables.jpg"));
            lista.Add(new Libro("El tambor de hojalata","Günter Grass","A través de la vida de Oskar Matzerath,un niño que decide dejar de crecer,la novela refleja la historia de la Alemania de entreguerras.","Editorial Seix Barral",576,1959,5, "el_tambor_de_hojalata.jpg"));
            lista.Add(new Libro("La señora Dalloway","Virginia Woolf","Una exploración del día a día de Clarissa Dalloway,mientras prepara una fiesta en Londres,mientras se entrelazan temas como la memoria y el paso del tiempo.","Harcourt",216,1925,5, "la_senora_dalloway.jpg"));
            //VARIOS
            lista.Add(new Libro("El fantasma de la ópera","Gaston Leroux","La historia de un misterioso hombre que habita en los pasadizos de la ópera de París y su amor no correspondido por una joven cantante.","Le Livre de Poche",366,1910,6, "el_fantasma_de_la_opera.jpg"));
            lista.Add(new Libro("Moby Dick","Herman Melville","El viaje de un barco ballenero liderado por el capitán Ahab,quien persigue obsesivamente a la ballena blanca que le arrancó la pierna.","Penguin Classics",720,1851,11, "moby_dick.jpg"));
            lista.Add(new Libro("La vida secreta de las abejas","Sue Monk Kidd","Una joven huérfana se escapa con su niñera y encuentra un hogar con tres hermanas que crían abejas.","Penguin Books",336,2002,8, "la_vida_secreta_de_las_abejas.jpg"));
            lista.Add(new Libro("La voz dormida","Dulce Chacón","El drama de la posguerra española a través de la vida de varias mujeres encarceladas por sus ideales políticos.","Editorial Planeta",416,2002,5, "la_voz_dormida.jpg"));
            lista.Add(new Libro("Crónica de una muerte anunciada","Gabriel García Márquez","Un pueblo vive con la certeza de que un asesinato ocurrirá,pero nadie lo impide.","Editorial Mondadori",120,1981,3, "cronica_de_una_muerte_anunciada.jpg"));
            lista.Add(new Libro("Cien años de soledad","Gabriel García Márquez","Una saga familiar que abarca varias generaciones,explorando la historia y las tradiciones del pueblo ficticio de Macondo.","Editorial Sudamericana",448,1967,10, "cien_anos_de_soledad.jpg"));
            lista.Add(new Libro("1984","George Orwell","Una distopía sobre un régimen totalitario que controla cada aspecto de la vida humana,incluida la mente.","Secker & Warburg",328,1949,9, "1984.jpg"));
            lista.Add(new Libro("El gran Gatsby","F. Scott Fitzgerald","La historia de Jay Gatsby,un hombre rico obsesionado con el amor de Daisy Buchanan durante la era del jazz.","Charles Scribners Sons",180,1925,8, "el_gran_gatsby.jpg"));
            lista.Add(new Libro("Cumbres Borrascosas","Emily Brontë","Una historia de amor y venganza entre Catherine Earnshaw y Heathcliff en los páramos ingleses.","Thomas Cautley Newby",416,1847,7, "cumbres_borrascosas.jpg"));
            lista.Add(new Libro("La sombra del viento","Carlos Ruiz Zafón","Un joven descubre un libro en la misteriosa biblioteca de un autor olvidado,desatando una serie de eventos oscuros.","Editorial Planeta",496,2001,3, "la_sombra_del_viento.jpg"));
            lista.Add(new Libro("Orgullo y prejuicio","Jane Austen","La historia de Elizabeth Bennet y su lucha por superar las diferencias sociales en su relación con el aristócrata Mr. Darcy.","T. Egerton",279,1813,7, "orgullo_y_prejuicio.jpg"));
            lista.Add(new Libro("Anna Karenina","Lev Tolstói","La trágica historia de amor entre Anna Karenina y el conde Vronski en la Rusia del siglo XIX.","The Russian Messenger",864,1878,7, "anna_karenina.jpg"));
            lista.Add(new Libro("La historia interminable","Michael Ende","Un joven lee un libro mágico que lo transporta a un mundo fantástico donde él mismo juega un papel crucial.","Knesebeck Verlag",416,1979,1, "la_historia_interminable.jpg"));
            lista.Add(new Libro("El código Da Vinci","Dan Brown","Un thriller que explora secretos religiosos y conspiraciones a través de un asesinato en el Museo del Louvre.","Doubleday",454,2003,3, "el_codigo_da_vinci.jpg"));
            lista.Add(new Libro("El diario de Ana Frank","Ana Frank","El diario de una niña judía que se oculta con su familia durante la ocupación nazi de los Países Bajos.","Contact Publishing",283,1947,5, "el_diario_de_ana_frank.jpg"));
            lista.Add(new Libro("La insoportable levedad del ser","Milan Kundera","Una exploración filosófica y emocional de las vidas entrelazadas de varios personajes en la Checoslovaquia comunista.","Editions Gallimard",320,1984,8, "la_insoportable_levedad_del_ser.jpg"));
            lista.Add(new Libro("El alquimista","Paulo Coelho","La búsqueda de Santiago,un joven pastor que sigue su sueño de encontrar un tesoro en Egipto.","Rocco",208,1988,11, "el_alquimista.jpg"));
            lista.Add(new Libro("La chica del tren","Paula Hawkins","Una mujer se convierte en testigo involuntaria de un crimen después de observar la vida de una pareja desde el tren.","Riverhead Books",395,2015,3, "la_chica_del_tren.jpg"));
            lista.Add(new Libro("El nombre de la rosa","Umberto Eco","Un monje franciscano investiga una serie de misteriosos asesinatos en una abadía medieval.","Bompiani",536,1980,3, "el_nombre_de_la_rosa.jpg"));
            lista.Add(new Libro("La carretera","Cormac McCarthy","Un padre y su hijo intentan sobrevivir en un mundo post-apocalíptico,mientras luchan por mantener su humanidad.","Alfred A. Knopf",287,2006,8, "la_carretera.jpg"));
            lista.Add(new Libro("Don Quijote de la Mancha","Miguel de Cervantes","Las aventuras de un caballero loco y su fiel escudero,Sancho Panza,en su lucha por hacer el bien.","Francisco de Robles",1056,1605,11, "don_quijote_de_la_mancha.jpg"));
            lista.Add(new Libro("El túnel","Ernesto Sabato","La historia de un hombre obsesionado con una mujer,llevándolo a un crimen y a una introspectiva existencial.","Editorial Sur",288,1948,3, "el_tunel.jpg"));
            lista.Add(new Libro("En busca del tiempo perdido","Marcel Proust","La búsqueda de la memoria y la identidad a través de las experiencias de un joven en la sociedad francesa.","Gallimard",4215,1913,8, "en_busca_del_tiempo_perdido.jpg"));
            lista.Add(new Libro("Matar a un ruiseñor","Harper Lee","La historia de una niña que crece en el sur de los Estados Unidos y es testigo de los prejuicios raciales en su comunidad.","J.B. Lippincott & Co.",324,1960,8, "matar_a_un_ruiseñor.jpg"));
            lista.Add(new Libro("El retrato de Dorian Gray","Oscar Wilde","La historia de un joven cuya apariencia nunca envejece mientras su alma se corrompe por sus acciones.","Ward,Lock & Co.",276,1890,3, "el_retrato_de_dorian_gray.jpg"));
            lista.Add(new Libro("Fahrenheit 451","Ray Bradbury","En un futuro distópico,los libros son quemados por el gobierno para evitar la libertad de pensamiento.","Ballantine Books",158,1953,9, "fahrenheit_451.jpg"));
            lista.Add(new Libro("La casa de los espíritus","Isabel Allende","La historia de una familia chilena a lo largo de varias generaciones,marcada por lo sobrenatural.","Editorial Plaza & Janés",496,1982,11, "la_casa_de_los_espiritus.jpg"));
            lista.Add(new Libro("Las intermitencias de la muerte","José Saramago","Un hombre comienza a experimentar la muerte que se detiene en una ciudad,llevando a una crisis existencial y social.","Editorial Seix Barral",266,2005,8, "las_intermitencias_de_la_muerte.jpg"));
            lista.Add(new Libro("En llamas","Suzanne Collins","El segundo libro de la trilogía de Los juegos del hambre,donde Katniss Everdeen se enfrenta a una nueva amenaza totalitaria.","Scholastic Press",391,2009,3, "en_llamas.jpg"));
            lista.Add(new Libro("Harry Potter y la piedra filosofal","J.K. Rowling","Un niño descubre que es un mago y comienza su educación en la escuela Hogwarts de Magia y Hechicería.","Bloomsbury",223,1997,1, "harry_potter_piedra_filosofal.jpg"));
            lista.Add(new Libro("Las crónicas de Narnia","C.S. Lewis","Un grupo de niños se adentra en un mundo mágico lleno de criaturas fantásticas y grandes aventuras.","Geoffrey Bles",208,1950,1, "el_leon_la_bruja_y_el_armario.jpg"));
            lista.Add(new Libro("La naranja mecánica","Anthony Burgess","En un futuro distópico,un joven y su banda de amigos se entregan a actos violentos antes de ser sometidos a una terapia de control mental.","Heinemann",192,1962,9, "la_naranja_mecanica.png"));
            lista.Add(new Libro("El viejo y el mar","Ernest Hemingway","La historia de un anciano pescador que lucha con un gigantesco marlín en las aguas del Caribe.","Charles Scribners Sons",128,1952,11, "el_viejo_y_el_mar.jpg"));
            lista.Add(new Libro("El retrato de un artista adolescente","James Joyce","Las experiencias de un joven mientras lucha con su identidad artística y su relación con la religión.","B. W. Huebsch",304,1916,8, "el_retrato_de_un_artista_adolescente.jpg"));
            lista.Add(new Libro("La ladrona de libros","Markus Zusak","Una joven encuentra consuelo en los libros mientras vive en la Alemania nazi,durante la Segunda Guerra Mundial.","Picador",552,2005,5, "la_ladrona_de_libros.jpg"));
            lista.Add(new Libro("La ciudad y los perros","Mario Vargas Llosa","Un grupo de jóvenes cadetes militares luchan por sobrevivir en la dura realidad de su institución.","Editorial Seix Barral",480,1963,8, "la_ciudad_y_los_perros.jpg"));
            lista.Add(new Libro("La peste","Albert Camus","En una ciudad de Argelia,una epidemia de peste obliga a sus habitantes a enfrentarse al absurdo de la existencia humana.","Gallimard",367,1947,8, "la_peste.jpg"));
            lista.Add(new Libro("Los detectives salvajes","Roberto Bolaño","La historia de dos poetas y su búsqueda por entender el misterio de un escritor desaparecido.","Anagrama",560,1998,8, "los_detectives_salvajes.jpg"));
            lista.Add(new Libro("El lobo estepario","Hermann Hesse","Un hombre dividido entre su vida civilizada y su deseo de liberarse de las restricciones sociales.","Suhrkamp Verlag",250,1927,8, "el_lobo_estepario.jpg"));
            lista.Add(new Libro("La torre oscura","Stephen King","Una épica historia de un pistolero en busca de la Torre Oscura,en un mundo post-apocalíptico.","Viking Penguin",400,1982,1, "la_torre_oscura.jpg"));
            lista.Add(new Libro("La isla del tesoro","Robert Louis Stevenson","Un joven se embarca en una peligrosa aventura para encontrar un tesoro escondido en una isla misteriosa.","Cassell & Company",296,1883,11, "la_isla_del_tesoro.jpg"));
            lista.Add(new Libro("La guerra de los mundos","H.G. Wells","Una invasión de la Tierra por parte de marcianos,explorando la supervivencia humana frente a un enemigo tecnológico superior.","William Heinemann",336,1898,3, "la_guerra_de_los_mundos.jpg"));
            //TERROR
            lista.Add(new Libro("It","Stephen King","Un grupo de niños se enfrenta a una entidad maligna que se presenta como sus peores miedos,incluido un payaso asesino.","Viking Penguin",1138,1986,6, "it.jpg"));
            lista.Add(new Libro("Drácula","Bram Stoker","La clásica historia de terror sobre el conde Drácula y su intento de trasladarse desde Transilvania a Inglaterra.","Archibald Constable and Company",416,1897,6, "dracula.jpg"));
            lista.Add(new Libro("El resplandor","Stephen King","Un hombre se ve consumido por la locura mientras trabaja en un hotel aislado con su familia durante el invierno.","Doubleday",447,1977,6, "el_resplandor.jpg"));
            lista.Add(new Libro("Frankenstein","Mary Shelley","La historia de un científico que crea una criatura,sólo para ser arrastrado por las consecuencias de su propia ambición.","Lackington,Hughes,Harding,Mavor & Jones",280,1818,6, "frankenstein.jpg"));
            lista.Add(new Libro("El exorcista","William Peter Blatty","La lucha entre el bien y el mal cuando una niña es poseída por una entidad demoníaca.","Harper & Row",416,1971,6, "el_exorcista.jpg"));
            lista.Add(new Libro("La maldición de Hill House","Shirley Jackson","Cuatro personas se enfrentan a fenómenos paranormales en una mansión aislada.","Viking Press",182,1959,6, "la_maldicion_de_hill_house.jpg"));
            lista.Add(new Libro("Cementerio de animales","Stephen King","Una familia descubre el oscuro poder de un cementerio que trae a los muertos de vuelta a la vida.","Doubleday",374,1983,6, "cementerio_de_animales.jpg"));
            lista.Add(new Libro("Carrie","Stephen King","Una joven con poderes psíquicos toma venganza tras ser humillada en su graduación escolar.","Doubleday",199,1974,6, "carrie.jpg"));
            lista.Add(new Libro("La sombra sobre Innsmouth","H.P. Lovecraft","Un hombre investiga una ciudad costera llena de secretos oscuros y criaturas sobrenaturales.","Visionary Publishing",104,1936,6, "la_sombra_sobre_innsmouth.jpg"));
            lista.Add(new Libro("La llamada de Cthulhu","H.P. Lovecraft","Un investigador descubre la existencia de un culto oculto que adora a un dios primigenio llamado Cthulhu.","Visionary Publishing",65,1928,6, "la_llamada_de_cthulhu.jpg"));
            //ROMANCE
            lista.Add(new Libro("Bajo la misma estrella","John Green","Una joven con cáncer se enamora de un chico que también lucha contra la enfermedad.","Dutton Books",313,2012,7, "bajo_la_misma_estrella.jpg"));
            lista.Add(new Libro("Crepúsculo","Stephenie Meyer","El romance entre una humana,Bella Swan,y un vampiro,Edward Cullen.","Little,Brown and Company",498,2005,7, "crepusculo.jpg"));
            lista.Add(new Libro("Lo que el viento se llevó","Margaret Mitchell","Una joven sureña lucha por sobrevivir durante la Guerra Civil y la reconstrucción de los Estados Unidos.","Macmillan Publishers",1037,1936,7, "lo_que_el_viento_se_llevo.jpg"));
            lista.Add(new Libro("Me before you","Jojo Moyes","La historia de Louisa,una joven que cuida a un hombre tetrapléjico y la conexión que desarrollan.","Penguin Books",369,2012,7, "me_before_you.jpg"));
            lista.Add(new Libro("Los puentes de Madison County","Robert James Waller","Un breve pero apasionado romance entre una ama de casa y un fotógrafo itinerante en Iowa.","Warner Books",192,1992,7, "los_puentes_de_madison_county.png"));
            lista.Add(new Libro("Eleanor & Park","Rainbow Rowell","La historia de amor entre dos jóvenes de secundaria en los años 80,marcada por la música y las diferencias sociales.","St. Martins Press",328,2012,7, "eleanor_park.jpg"));
            lista.Add(new Libro("Saga","Brian K. Vaughan y Fiona Staples","Un cómic de ciencia ficción y romance sobre una familia intergaláctica que lucha por sobrevivir.","Image Comics",128,2012,7, "saga.jpg"));
            //DISTOPIA
            lista.Add(new Libro("Los juegos del hambre","Suzanne Collins","En un futuro distópico,un joven participa en un evento mortal transmitido por televisión.","Scholastic Press",374,2008,9, "los_juegos_del_hambre.jpg"));
            lista.Add(new Libro("El cuento de la criada","Margaret Atwood","En un futuro totalitario,las mujeres son forzadas a ser reproductoras en un régimen opresivo.","McClelland & Stewart",311,1985,9, "el_cuento_de_la_criada.png"));
            lista.Add(new Libro("La carretera","Cormac McCarthy","Un padre y su hijo viajan a través de una América post-apocalíptica en busca de un futuro mejor.","Alfred A. Knopf",287,2006,9, "la_carretera.jpg"));
            lista.Add(new Libro("V for Vendetta","Alan Moore y David Lloyd","En una Inglaterra distópica gobernada por un régimen fascista,un hombre lucha por la libertad.","DC Comics",296,1988,9, "v_de_vendetta.jpg"));
            lista.Add(new Libro("La caza","Chris Ryan","Un grupo de jóvenes debe luchar por sobrevivir en una sociedad futura que los ha manipulado desde su nacimiento.","Heinemann",415,2001,9, "la_caza.jpg"));
            lista.Add(new Libro("Nunca me abandones","Kazuo Ishiguro","Un grupo de amigos descubre que han sido creados para donar sus órganos en un futuro distópico.","Klaris Publishing",288,2005,9, "nunca_me_abandones.jpg"));
            lista.Add(new Libro("El dador","Lois Lowry","En una sociedad aparentemente perfecta,un joven descubre la oscura verdad detrás de su mundo controlado.","Houghton Mifflin Harcourt",225,1993,9, "el_dador.jpg"));
            //REALISMO MÁGICO
            lista.Add(new Libro("Cien años de soledad","Gabriel García Márquez","La historia de la familia Buendía,marcada por lo mágico y lo extraordinario en un pueblo de Colombia.","Editorial Sudamericana",417,1967,10, "cien_anos_de_soledad.jpg"));
            lista.Add(new Libro("La casa de los espíritus","Isabel Allende","Una familia chilena enfrenta el paso del tiempo,con elementos sobrenaturales y políticos que marcan su historia.","Editorial Plaza & Janés",468,1982,10, "la_casa_de_los_espiritus.jpg"));
            lista.Add(new Libro("Como agua para chocolate","Laura Esquivel","Un amor imposible entre Tita y Pedro,marcado por la tradición familiar y la magia en la cocina.","Editorial Planeta",256,1989,10, "como_agua_por_chocolate.jpg"));
            lista.Add(new Libro("El otoño del patriarca","Gabriel García Márquez","Un dictador envejece en su solitaria mansión,mientras enfrenta el paso del tiempo y el poder absoluto.","Editorial Sudamericana",250,1975,10, "el_otono_del_patriarca.jpg"));
            lista.Add(new Libro("La invención de Morel","Adolfo Bioy Casares","Un hombre busca a la mujer que ama en una isla misteriosa,donde la realidad parece estar distorsionada.","Editorial Sur",155,1940,10, "la_invencion_de_morel.jpg"));
            lista.Add(new Libro("Pedro Páramo","Juan Rulfo","Un joven viaja a Comala para encontrar a su padre,solo para descubrir que el pueblo está lleno de fantasmas.","Editorial Fondo de Cultura Económica",125,1955,10, "pedro_paramo.jpg"));
            lista.Add(new Libro("El almuerzo desnudo","William S. Burroughs","Una novela surrealista en la que se mezclan drogas,conspiraciones y una visión distorsionada de la realidad.","Grove Press",212,1959,10, "el_almuerzo_desnudo.jpg"));
            lista.Add(new Libro("La isla de los conejos","Juan José Saer","Una historia que mezcla lo real y lo fantástico,mostrando un paisaje que se vuelve protagonista de la trama.","Editorial Anagrama",200,2008,10, "la_isla_de_los_conejos.jpg"));
            lista.Add(new Libro("Los detectives salvajes","Roberto Bolaño","La historia de dos poetas y su búsqueda por entender el misterio de un escritor desaparecido.","Anagrama",560,1998,10, "los_detectives_salvajes.jpg"));
            lista.Add(new Libro("La tregua","Mario Benedetti","Un hombre comienza una relación con una joven que le da una tregua a su rutinaria vida.","Editorial Planeta",220,1960,7, "la_tregua.jpg"));
            lista.Add(new Libro("Promesa de sangre", "Brian McClellan", "Derrocar a un rey es un trabajo sangriento.\r\n El mariscal de campo Tamas ha liderado el golpe de estado en Adro.\r\n La aristocracia decadente y corrupta ha terminado en la guillotina y el pueblo hambriento ahora tiene comida.\r\n Pero además ha provocado la guerra en las Nueve Naciones, ataques internos de los realistas y lucha encarnizada por el dinero y el poder entre quienes suponía eran sus aliados: la Iglesia, los trabajadores y los mercenarios.\r\n Tamas apenas soporta la presión y necesita a Adamat, un inspector de policía retirado, cuya lealtad está en juego, y a los Magos de la Pólvora que le quedan, entre ellos Taniel, su indómito y brillante hijo.\r\n Hay quienes presagian muerte y destrucción.\r\n Las leyendas están en boca del pueblo pero ningún hombre instruido cree en ese tipo de cosas... aunque sería mejor que lo hicieran.\r\n Los dioses también están implicados", "Gamon Fantasy", 564, 2021, 1, "promesa_de_sangre.jpg"));

            foreach (Libro l in lista)
            {
                l.insert();
            }
        }
    }
}
