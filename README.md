# PEC 3 - Un Juego de Plataformas

Este juego ha sido realizado por el alumno Javier Riera para la asignatura de Programación de Videojuegos 3D.

## Sinopsis

Eres una abuelita que, durante su paseo matutino, ha visto su pueblecito invadido por zombies. Por suerte, eres una abuela de Estados Unidos, así que encontrar un arma y munición no ha sido difícil. ¡Ábrete paso hasta llegar al helicóptero que te recogerá!

## Controles

Se puede jugar con ratón y teclado o mando. Con el ratón y teclado, usa el WASD para moverte y el ratón para apuntar. Con el click izquierdo disparas y con la R recargas las balas. Con el espacio reproduces la animación de salto.

En un mando de PS3, probado en Manjaro Linux, los controles son de movimiento con el joystick izquierdo, apuntar con el derecho, disparar con el R1, recargar con cuadrado y saltar con la equis.

## Enemigos

Hay dos enemigos implementados. Los zombies normales y los zombies gigantes. Estos últimos tienen más vida, hacen más daño y son más lentos. Eso sí, puede que te interese llegar a la zona en la que merodean. Los identificarás rápidamente porque son más grandes y de un tono rojizo con respecto al resto.

## Objetos útiles

Por el mapa encontrarás tanto munición como botiquines. Los botiquines solo se usarán si te hace falta curarte al menos un punto de vida, mientras que las cajas de munición sumarán inmediatamente el número de balas que cabe en cada cargador a tu pistola.

## Mejoras a introducir

Por cómo se ha realizado la arquitectura del proyecto, añadir armas nuevas se podría hacer en unas pocas horas, simplemente habría que crear nuevas instancias del ScriptableObject "Weapon" y crear un sistema que permitiese recoger y cambiar de armas.

Además, añadir zombies nuevos también es sencillo. Se pueden modificar sus ataques y vida mediante instancias de ScriptableObjects, y basta con hacer un prefab con los modelos cambiados (color, tamaño, etc...).

## Vídeo demostrativo

https://gitlab.com/mrvizious/programacion-3d-pec-3-un-juego-de-plataformas/-/blob/master/Videos/Granny-2020-12-06_21.36.47.mp4
