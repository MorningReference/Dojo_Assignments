class Ninja {
  constructor(name, health, speed = 3, strength = 3) {
    this.name = name;
    this.health = health;
    this.speed = speed;
    this.strength = strength;
  }
  sayName() {
    console.log(this.name);
  }
  showStats() {
    console.log(
      'Name: ' +
        this.name +
        ', Health: ' +
        this.health +
        ', Strength: ' +
        this.strength +
        ', Speed: ' +
        this.speed
    );
    // return [this.name, this.strength, this.speed, this.health];
  }
  drinkSake() {
    this.health += 10;
  }
}

const ninja1 = new Ninja('Hyabusa', 10);
ninja1.sayName();
ninja1.showStats();
ninja1.drinkSake();
ninja1.showStats();

class Sensei extends Ninja {
  constructor(name, health, speed, strength, wisdom = 10) {
    super(name, (health = 200), (speed = 10), (strength = 10));
    this.wisdom = wisdom;
  }
  speakWisdom() {
    const drinkSake = super.drinkSake();
    console.log('Words of wisdom is wisest when in a fortune cookie.');
    drinkSake;
  }
}

const superSensei = new Sensei('Master Splinter');
superSensei.speakWisdom();
superSensei.showStats();
