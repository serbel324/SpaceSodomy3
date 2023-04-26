using Godot;
using System;

public class Damage {
    public float magnitude { get; }
}

public class Health {
    public float hp { get; set; }
    public float maxHp { get; }

    public Health(float maxHp) {
        this.maxHp = maxHp;
        hp = maxHp;
    }

    public Health(float hp, float maxHp) {
        this.hp = hp;
        this.maxHp = maxHp;
    }

    public bool DealDamage(Damage damage) {
        hp -= damage.magnitude;
        if (hp < Mathf.Epsilon) {
            return false;
        }
        return true;
    }

    public void Revive() {
        hp = maxHp;
    }
}

public abstract partial class LivingThing : Node2D {
    [Export]
    public float maxHp = 10;
    [Export]
    public bool isImmortal = false;

    protected Health _health;

    public LivingThing() {
        _health = new Health(maxHp);
    }

    public bool alive { get; protected set; }

    public virtual void DealDamage(Damage damage) {
        if (isImmortal) {
            return;
        }

        alive &= _health.DealDamage(damage);
        if (!alive) {
            _Die();
        }
    }

    protected abstract void _Die(); // Called when _hp is zero
}

public class UnexpetedDeathException : System.Exception {
    public String epitaphy { get; }

    public UnexpetedDeathException(String epitaphy) {
        this.epitaphy = epitaphy;
    }
}
