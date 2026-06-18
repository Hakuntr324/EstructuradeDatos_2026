# EB7 - Cuestionario de Evaluación: Anatomía de la Recursividad

## 1. Conceptual
**Pregunta:** Define con tus propias palabras qué es la recursividad. ¿En qué se diferencia fundamentalmente de un ciclo while o for? Da un ejemplo de un problema que sea más natural expresar de forma recursiva.

**Respuesta:** La recursividad es una técnica de programación donde una función se resuelve a sí misma llamándose una o más veces, utilizando la estrategia de "Divide y Vencerás" para romper un problema complejo en subproblemas más pequeños. A diferencia de los ciclos `for` o `while` que usan variables locales y un espacio de memoria constante, la recursividad utiliza la memoria del Call Stack, creando un marco de activación por cada llamada. Un ejemplo natural para usar recursividad es la exploración de sistemas de archivos (carpetas dentro de carpetas), algoritmos en árboles binarios o problemas matemáticos como las Torres de Hanói.

---

## 2. Análisis de Código
**Pregunta**: El siguiente código tiene un error crítico. Identifícalo, explica qué excepción produciría en tiempo de ejecución y corrígelo:
```csharp
static int Factorial(int n)
{
    return n * Factorial(n - 1);
}


Respuesta: * Error crítico: El código carece por completo de un Caso Base, que es la condición de salida obligatoria para detener las llamadas recursivas.Excepción que produce: Al no tener un freno, la función se llamará infinitamente hacia valores negativos hasta agotar la memoria finita de la pila, lanzando una excepción StackOverflowException que colapsará el programa de forma abrupta en .NET.Código Corregido:C#static int Factorial(int n)
{
    // Caso Base obligatorio para detener la recursión
    if (n <= 1) 
        return 1;

    // Caso Recursivo que reduce el problema
    return n * Factorial(n - 1);
}
3. Call StackPregunta: Dibuja o describe en texto el estado exacto del Call Stack en cada paso cuando se ejecuta SumarHasta(4). Indica cuántos marcos de activación hay en memoria en el punto de máxima profundidad y cuál es el orden en que se liberan.

Respuesta: Fase de Invocación (Apilado):
Paso 1: SumarHasta(4) -> Espera el resultado de: 4 + SumarHasta(3) [Pila: 4]

Paso 2: SumarHasta(3) -> Espera el resultado de: 3 + SumarHasta(2) [Pila: 4, 3]

Paso 3: SumarHasta(2) -> Espera el resultado de: 2 + SumarHasta(1) [Pila: 4, 3, 2]

Paso 4: SumarHasta(1) -> Alcanza el Caso Base y retorna 1 [Pila: 4, 3, 2, 1]

Máxima profundidad: En este punto hay 4 marcos de activación simultáneos ocupando espacio en la memoria RAM.

4. Aplicación
Pregunta: Un compañero afirma que siempre es mejor usar un ciclo for en lugar de recursividad porque es más eficiente en memoria. ¿Estás de acuerdo? Argumenta tu respuesta mencionando al menos un caso donde la recursividad es la herramienta superior.

Respuesta: Estoy de acuerdo parcialmente en la parte de la eficiencia. Los ciclos for son más eficientes en memoria porque no saturan la pila de llamadas (Call Stack). Sin embargo, no siempre es el mejor enfoque. En problemas con estructuras de datos jerárquicas o ramificadas (como la búsqueda en grafos, árboles de decisión en Inteligencia Artificial o fractales), un ciclo for se vuelve extremadamente complejo de escribir, leer y mantener. En esos escenarios, la recursividad es una herramienta superior porque aporta una alta legibilidad y una traducción directa, limpia y elegante de la estructura del problema.

5. Prediction
Pregunta: ¿Qué imprimiría en consola la siguiente llamada: ImprimirCuentaRegresiva(3)? Escribe la salida esperada línea por línea sin ejecutar el código.

Respuesta: La salida exacta que genera en consola siguiendo ordenadamente las fases de apilado y desapilado LIFO de la memoria es la siguiente: