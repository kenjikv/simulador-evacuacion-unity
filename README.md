# Simulacro de evacuación en Unity 6

Proyecto completo del tutorial en video «Simulacro de evacuación en Unity 6, paso a paso». Es un simulacro jugable en primera persona: suena la alarma, la ruta principal se llena de humo y hay que salir por la puerta de emergencia hasta el punto de encuentro antes de que se acabe el tiempo.

## Qué tiene

- Un edificio de dos salas con patio, armado con ProBuilder y prefabs.
- Un jugador en primera persona con Character Controller y el Input System.
- Objetos que se usan con la tecla E: puertas con bisagra, un interruptor y un pulsador de alarma.
- Una máquina de estados (Inicio, Normal, Emergencia, Éxito y Fracaso) con reloj, objetivos, penalizaciones y pantalla de resultados.
- Una ruta bloqueada con humo y escombros, y una zona segura.
- Letreros que laten con un Shader Graph, luces rojas de emergencia, posproceso con Volume y una sirena.
- Una persona que evacúa sola con NavMesh.

## Requisitos

- Unity 6000.4.9f1 (Unity 6.4) desde Unity Hub.
- Los paquetes (URP 17.4, ProBuilder 6.0.9, AI Navigation 2.0.12, Input System 1.19) se descargan solos al abrir el proyecto.

## Cómo abrirlo

1. Clona el repositorio o descárgalo como ZIP.
2. En Unity Hub, elige **Add › Add project from disk** y selecciona la carpeta.
3. Abre la escena `Assets/Scenes/Escenario.unity` y pulsa Play.

## Controles

| Tecla | Acción |
| --- | --- |
| W, A, S, D | Caminar |
| Ratón | Mirar |
| Shift | Correr |
| E | Usar puertas, interruptor y alarma |
| Enter | Empezar el simulacro |
| R | Reiniciar |
| Esc | En el editor suelta el ratón; en el ejecutable cierra el programa |

## Cómo se juega

1. Pulsa Enter en la pantalla de bienvenida.
2. Busca el pulsador rojo en la sala 1 y úsalo con E: suena la alarma y empieza a correr el reloj de 60 segundos.
3. La salida por la sala 2 queda bloqueada con humo y escombros. Sal por la puerta de emergencia de la pared sur.
4. Llega a la zona verde del patio. Entrar al humo resta 20 puntos y llegar después de 30 segundos resta 10.

## Dónde está cada cosa

| Carpeta | Contenido |
| --- | --- |
| `Assets/Scripts` | Movimiento del jugador y límite del escenario |
| `Assets/Scripts/Interaccion` | Contrato de interacción, rayo del jugador, puerta, interruptor y letrero |
| `Assets/Scripts/Simulacion` | Estados del simulacro, alarma, objetivos, humo, zona segura y resultados |
| `Assets/Scripts/Ambiente` | Luces de emergencia y la persona que evacúa |
| `Assets/Materiales` | Materiales y el Shader Graph `SG_Senal` |
| `Assets/Prefabs` | Piso, paredes, puerta, interruptor y letrero |

## Créditos

- El pictograma de salida (`Assets/Texturas/Pictograma_Salida.png`) se generó con IA. Sirve cualquier imagen PNG.
- El sonido de la alarma (`Assets/Audio/Alarma.wav`) se generó con ffmpeg.
