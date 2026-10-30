# Brick Breaker 3D 🧱

3D демо-игра на **C# (.NET 8)** + **OpenTK (OpenGL 3.3)** с полностью **кастомной физикой** (без физических движков).

## Геймплей
- Стена из кирпичей (кубов), пол, камера от первого лица.
- **WASD** — движение камеры, **мышь** — обзор, **F** — выстрел шаром.
- Шар разрушает стену: кирпичи теряют связь со стеной, получают импульс, разлетаются и падают на пол.

## Физика (written by hand)
- Гравитация, масса, скорость, импульсы.
- Коллизии: **Сфера ↔ Куб**, **Куб ↔ Куб (AABB)**, **Куб/Сфера ↔ Плоскость (пол)**.
- Коэффициенты упругости (restitution) и трения.

## Структура проекта
```
BrickBreaker3D/
├── BrickBreaker3D.csproj
├── shaders/model.vert, model.frag   # GLSL шейдеры (диффузное освещение)
└── src/
    ├── Program.cs          # инициализация окна OpenTK
    ├── Game.cs             # игровой цикл (Update / Render)
    ├── Camera.cs           # FPS-камера (View/Projection)
    ├── Shader.cs           # компиляция GLSL
    ├── EmbeddedShaders.cs  # шейдеры, встроенные в EXE
    ├── Mesh.cs             # генерация куба и сферы
    ├── PhysicsObject.cs    # тело: позиция, скорость, масса
    └── PhysicsEngine.cs    # гравитация, коллизии, импульсы
Release/
└── BrickBreaker3D.exe      # готовый self-contained билд (Windows x64)
.github/workflows/build.yml # CI: сборка EXE + GitHub Release
```

## Сборка
```bash
dotnet publish BrickBreaker3D -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o Release
```

## Скачать
Готовый EXE — в разделе [Releases](../../releases) (архив `BrickBreaker3D-win-x64.zip`), либо файл `Release/BrickBreaker3D.exe` прямо в репозитории.

## Управление
| Клавиша | Действие |
|---|---|
| W/A/S/D | Движение |
| Мышь | Обзор |
| F | Выстрел шаром |
| Esc | Выход |
