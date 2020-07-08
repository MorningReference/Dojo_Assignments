class Card {
  constructor(name, cost) {
    this.name = name;
    this.cost = cost;
  }
  summon(playerName) {
    console.log('Player ' + playerName + ' summoned ' + this.name);
  }
}

class Unit extends Card {
  constructor(name, cost, power, res) {
    super(name, cost);
    this.power = power;
    this.res = res;
  }
  attack(target, playerName) {
    target.res -= this.power;
    console.log(
      'Player ' +
        playerName +
        ' had ' +
        this.name +
        ' attack ' +
        target.name +
        ' and dealt ' +
        this.power +
        ' damage'
    );
  }
}

class Effect extends Card {
  constructor(name, cost, text, stat, magnitude) {
    super(name, cost);
    this.text = text;
    this.stat = stat;
    this.magnitude = magnitude;
  }
  play(target, playerName) {
    if (target instanceof Unit) {
      if (this.stat == 'power') target.power += this.magnitude;
      else target.res += this.magnitude;
      console.log(
        'Player ' +
          playerName +
          ' played ' +
          this.name +
          ' on ' +
          target.name +
          ' and it ' +
          this.text
      );
    } else {
      throw new Error('Target must be a unit!');
    }
  }
}

let RedBeltNinja = new Unit('Red Belt Ninja', 3, 3, 4);
let BlackBeltNinja = new Unit('Black Belt Ninja', 4, 5, 4);

let HardAlgorithm = new Effect(
  'Hard Algorithm',
  2,
  "Increase target's resilience by 3",
  'res',
  3
);
let UnhandledPromiseRejection = new Effect(
  'Unhandled Promise Rejection',
  1,
  "Reduce target's resilience by 2",
  'res',
  -2
);
let PairProgramming = new Effect(
  'Pair Programming',
  3,
  "Increase target's power by 2",
  'power',
  2
);

RedBeltNinja.summon(1);
HardAlgorithm.play(RedBeltNinja, 1);
BlackBeltNinja.summon(2);
UnhandledPromiseRejection.play(RedBeltNinja, 2);
PairProgramming.play(RedBeltNinja, 1);
RedBeltNinja.attack(BlackBeltNinja, 1);
