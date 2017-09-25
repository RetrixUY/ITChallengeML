# ITChallengeML
Algunas de mis soluciones para el ITChallenge 2017 de MercadoLibre.com
Voy Subiendo a medida que comento y dejo "presentable" el codigo
------------------------------------------------------------------------------------------------------------------

#### Level 27 - Uruguay - Ciudad Perdida:
_Un equipo de científicos norteamericanos, descubrió un secreto que podría cambiar el curso de la humanidad.
Se cree que encontraron la ciudad perdida de la Atlántida.
Durante una expedición en la Antártida, descubrieron una capa de hielo que al ser penetrada por rayos ultravioletas genera una imagen misteriosa.
Debajo de la capa de hielo, hay una estatua de una reina y runas que permiten formar una frase .... al parecer, de colocar la frase correcta, se abriría la entrada al mundo perdido.
Debajo de la estatua se lee claramente: "¿Cuál es el nombre del canto de la reina?"_

**Solucion: Compila level27.cs y se generara un .wav, el nombre de la cancion es la solucion**

------------------------------------------------------------------------------------------------------------------

#### Level 26 - Canada (Solucion A Medias) - Misterio

_Hemos encontrado en un libro antiguo una hoja que luego de procesarla digitalmente contiene algo que parece ser tener algún sentido.
Lamentablemente aún no hemos podido descifrarlo, pero como en Mercado Libre disfrutamos mucho los desafíos, quisiéramos revelar el misterio. Vos te crees capaz de enfrentarlo?_

**Solucion (A Medias):** 
1. Compila level26.cs para obtener el morse de la imagen
2. Traduce el Morse: morsecode.scphillips.com/translator.html para obtener la conversacion entre 2 barcos
3. Convierte el Hexadecimal a ascii: www.rapidtables.com/convert/number/hex-to-ascii.htm para obtener otra parte de la conversacion
4. Decodifica el base64: https://www.base64decode.org/ para obtener la ultima parte de la conversacion y el problema final
5. Prueba suerte con el problema matematico (yo no pude resolverlo)

------------------------------------------------------------------------------------------------------------------

#### Level 18 - Brasil - Lenguajes Exóticos
_Hoy existen muchos lenguajes de programacion disponibles entre ellos hay un subgrupo muy particular conocidos como "Lenguajes exoticos" por su naturaleza particular, quizas no son los mas útiles del mundo pero nos permiten explorar nuevas formas de pensar.
Nos llegó el siguiente código escrito en algún extraño lenguaje de programación, con la peculiar característica de que durante su interpretación el programa se va desplazando físicamente por el código, con operadores de movimiento (<, >, ^, v):_
```
52*>: :000p1>\:00g-#v _ v
  v 2-1*2p00 :+1g00\<   $
  > **00g1+/^v,*84      <
  _^#<`  9:+1>#,.#+5<   @
```
_Nos gustaría saber cual es el resultado una vez ejecutado correctamente._

**Solucion: Conocia el lenguaje a pesar de ser bastante exotico, se llama Befunge, utilize un interprete online:**
http://qiao.github.io/javascript-playground/visual-befunge93-interpreter/

------------------------------------------------------------------------------------------------------------------
#### Level 7 - Estados Unidos - Help Me!

_Últimas noticias en Metrópolis, Jimmy Olsen inseparable colega de Clark Kent e intrépido socio de Superman ha desaparecido. La única pista tras su desaparición es un curioso mail recibido por Clark y Lois con el siguiente contenido:_

_Estimados Lois & Clark:_

_Me encuentro tras la historia de mi vida, si están leyendo este email y no han sabido de mi confio en que
la información adjunta en este correo guíe a Superman hacia mi paradero. Lamento no haberlos involucrado
antes pero me hubieran disuadido y como Lois siempre dice "No hay nada más importante que una historia"._

_Saludos.
Jimmy O.
Superman, nuestro superhéroe favorito, muy hábil con los músculos para bastante rústico con los acertijos nos solicita ayuda para hallar la pista detrás de los archivos adjuntos en el email de Jimmy. Ayúdalo a hallar su paradero!_

Podes encontrar el adjunto en https://s3.amazonaws.com/it.challenge/level7.zip

**Solucion:**
1. Decodificar el Base64 de cada texto contenido en el zip: https://www.base64decode.org/
2. Armar el puzzle con las imagenes obtenidas en el paso anterior
3. Obtener el Base64 Oculto en los metadatos de cada pieza del puzzle
4. Ordenar segun el puzzle los Base64 de Cada imagen y unirlos
5. Decodificar el Base64
6. La Respuesta esta en la imagen obtenida en el paso anterior

------------------------------------------------------------------------------------------------------------------

#### Level ?? - Venezuela - Paredes Pintadas

_Una máquina tiene que pintar una pared con diferentes alturas como la imagen siguiente:_
_https://mla-s2-p.mlstatic.com/977059-MLA25939519280_092017-F.jpg_

_Esta máquina tiene la característica que sólo pinta de forma horizontal. Cada trazo horizontal que realiza la máquina tiene un alto fijo y ancho arbitrario que depende de la pared que se desea pintar._

_La dificultad se encuentra en calcular la cantidad mínima de trazos horizontales que debe realizar la máquina para poder pintar la pared completa. En el caso del ejemplo, la máquina debe realizar 9 pasadas entre todos los pisos._

_La entrada de datos que define la pared viene dada por una serie de números separados por un espacio que determina la altura de la pared para ese piso y sección de la pared. En el caso del ejemplo, los datos serían 1, 3, 2, 1, 2, 1, 5, 3, 3, 4, 2. Dado los siguientes datos de entrada, determinar cuantos trazos horizontales mínimos debe realizar la máquina para pintar la pared de forma completa._

_1 4 5 6 7 8 15 12 9 4 9 8 12 14 22 45 67 89 87 86 85 23 56 67 21 88 11 44 56 91 67 45 45 45 45 45 44 21 89 90 90 87 45 91 12 45 57_

**Solucion: Compilar y Ejecutar levelVenezuela.cs**
