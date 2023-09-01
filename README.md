# GoF Patterns Abstract Factory, Visiter, Decorator & Mediator
 Practice using the "Abstract Factory", "Visiter", "Decorator", "Mediator" patterns in Unity 

 ### Абстрактная фабрика 
1. В игре с различными типами персонажей можно использовать паттерн абстрактная фабрика для создания экземпляров персонажей в зависимости от выбора игрока. Например, при выборе класса персонажа "воин" фабрика может создавать экземпляры воинов с различными характеристиками и способностями, а при выборе класса "маг" - экземпляры магов с уникальными заклинаниями.
2. В игре с системой создания предметов или крафта паттерн абстрактная фабрика может использоваться для создания предметов различных типов. Например, фабрика может создавать оружие, броню, зелья и другие предметы в зависимости от рецептов или комбинаций игровых ресурсов.

### Посетитель
1. В игре с системой управления игровым интерфейсом, паттерн визитер может использоваться для обновления элементов пользовательского интерфейса в зависимости от текущего состояния игры. Например, визитер может обновлять отображение здоровья персонажа, количество доступных ресурсов или информацию о текущей задаче.
2. В игре с системой коллизий и взаимодействия объектов, паттерн визитер может использоваться для обработки столкновений между различными объектами. Например, при столкновении персонажа с препятствием, визитер может определить, какие действия должны быть выполнены в результате этого столкновения, такие как урон, отскок или активация специального эффекта.

### Декоратор
1. В игре с системой эффектов и специальных умений, паттерн декоратор может использоваться для добавления дополнительных свойств или возможностей к персонажам или объектам. Например, декоратор может добавить временный бонус к силе атаки персонажа после использования определенного предмета или заклинания.
2. В игре с системой крафта или улучшения предметов, паттерн декоратор может использоваться для добавления новых свойств или модификаций к существующим предметам. Например, декоратор может добавить улучшение к оружию, которое повышает его урон или добавляет новые специальные эффекты.

### Медиатор
1. Управление ресурсами: Медиатор может служить посредником для управления ресурсами в игре Unity. Например, медиатор может координировать загрузку и выгрузку текстур, звуковых эффектов или анимаций, а также управлять их использованием в игровом мире.
2. Управление игровыми событиями: Медиатор может использоваться для управления игровыми событиями в Unity. Например, медиатор может отслеживать состояние игры и запускать определенные события, такие как начало нового уровня, окончание игры или активация определенных сценарных событий.



