# GDD (Documento de Diseño del Juego)
## PRESENTACIÓN/RESUMEN
- **Título**: Rambo Shooter

- **Concepto**: Rambo Shooter es un juego shooter 2D estilo Arcade en el que el jugador se enfrenta a un mapa lleno de enemigos que debe eliminar sin ser derrotado ni caer del mapa. El juego combina acción rápida, estrategia y reflejos para superar a todos los enemigos.

- **Género**: Shooter 2D, Arcade.

- **Público**: Todo tipo de público, desde gente joven hasta gente mas mayor ya que el juego tiene un estilo arcade y una facil jugabilidad.

- **Plataforma**: PC.

## GAMEPLAY
### Objetivos
El objetivo principal del jugador es eliminar a todos los enemigos en el mapa sin perder toda su vida o caer al vacío. La victoria se consigue al eliminar a todos los enemigos, mientras que la derrota ocurre si el jugador pierde toda su vida o cae fuera del mapa.

### Jugabilidad
- **Interacción**: El jugador controla a un personaje que puede moverse, saltar y disparar. Los enemigos reaccionan al acercamiento del jugador, comenzando a disparar en su dirección.

- **Sistemas de recompensas**: No hay un sistema de recompensas implementado por el momento.

- **Puzzles**: No hay puzzles, pero el jugador debe planificar sus movimientos y ataques para evitar ser rodeado o eliminado por los enemigos.

### Progresión
El juego no tiene un sistema de progresión tradicional. Cada partida es independiente, y el juego se mantiene constante.

### GUI (Interfaz Gráfica de Usuario)
- **Vida del jugador**: Se muestra en la esquina superior izquierda de la pantalla, representada una barra de salud.

- **Mapa**: El mapa es un tilemap de gran tamaño con plataformas y obstáculos. Los enemigos aparecen de forma aleatoria en diferentes ubicaciones del mapa.

## MECÁNICAS
### Reglas
El jugador debe eliminar a todos los enemigos sin perder toda su vida o caer del mapa.

Los enemigos comienzan a disparar cuando el jugador se acerca a ellos.

El jugador puede moverse, saltar y disparar para defenderse y atacar.

### Interacción
- Controles:

    - A/D o Izquierda/Derecha: Moverse horizontalmente.

    - W/Arriba: Saltar.

    - Espacio: Disparar.

### Puntaje
No hay un sistema de puntuación tradicional. El objetivo es sobrevivir y eliminar a todos los enemigos. Sin embargo, se muestra la vida del jugador como indicador de progreso y se podria implementar un sistema de puntos con cierta facilidad en un futuro.

### Dificultad
El juego no tiene niveles de dificultad ajustables, la dificultad se mantiene constante en cada nivel.

## ELEMENTOS DEL VIDEOJUEGO
### Worldbuilding
- Entorno: El juego se desarrolla en un mapa compuesto por plataformas y obstáculos. El diseño del mapa es variado, con áreas abiertas y zonas más estrechas que requieren precisión en los movimientos.

- Leyes físicas:

    - Colisiones: Los personajes y proyectiles interactúan con el entorno y entre sí.

    - Gravedad: Afecta al jugador y a los enemigos, haciendo que caigan si no están sobre una plataforma.

    - RigidBodies: Se utilizan para simular el movimiento y las interacciones físicas.

    - Colliders: se utilizan para dar una consistencia a las cosas y estan presentes en elementos como el personaje principal, balas enemigos o el propio Tilemap

### Historia
El jugador es un soldado atrapado  en una jungla  en una zona hostil  de Vietnam y  debe luchar para sobrevivir y escapar.

### Personajes
- Jugador: Un soldado armado con un arma básica. Su diseño es simple pero reconocible, con un estilo artístico pixelado o cartoon.

- Enemigos: Criaturas o soldados enemigos con comportamientos simples.

### Niveles
No hay niveles separados, pero el mapa está diseñado para ofrecer diferentes desafíos según la ubicación del jugador. Algunas áreas pueden ser más abiertas, mientras que otras son más estrechas y peligrosas.

### Elementos culturales o geográficos
El entorno se inspira en un paisaje selvatico inspirado en las míticas películas de Rambo en la jungla de Vietnam

## ASSETS
### Música
- Música de fondo emocionante y rápida para mantener el ritmo del juego.

- Efectos de sonido para disparos, y movimientos del jugador.

- Musicas diferentes para cuando el jugador gana o pierde la partida

### Efectos de sonido
Disparos.

Pasos y saltos.

### Modelos 2D/3D
Personajes: Sprites 2D para el jugador y los enemigos.

Entorno: Tilemap 2D con plataformas, obstáculos y fondos detallados.

Proyectiles: Sprites simples para balas.