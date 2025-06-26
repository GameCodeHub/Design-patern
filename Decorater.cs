using UnityEngine;

// Giao diện chung cho nhân vật
public interface ICharacter
{
    void TakeDamage(int amount);
}

// Lớp nhân vật cơ bản
public class BasicCharacter : ICharacter
{
    private int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"BasicCharacter took {amount} damage. Remaining health: {health}");
    }
}

// Lớp cơ sở cho các Decorator
public abstract class CharacterDecorator : ICharacter
{
    protected ICharacter character;

    public CharacterDecorator(ICharacter character)
    {
        this.character = character;
    }

    public virtual void TakeDamage(int amount)
    {
        character.TakeDamage(amount); // Hành vi mặc định
    }
}

// Decorator: Áo giáp
public class ArmorDecorator : CharacterDecorator
{
    private int armor = 10;

    public ArmorDecorator(ICharacter character) : base(character) { }

    public override void TakeDamage(int amount)
    {
        int reducedDamage = Mathf.Max(amount - armor, 0);
        Debug.Log($"Armor reduces damage by {armor}. Final damage: {reducedDamage}");
        base.TakeDamage(reducedDamage);
    }
}

// Decorator: Khiên
public class ShieldDecorator : CharacterDecorator
{
    private int shield = 20;

    public ShieldDecorator(ICharacter character) : base(character) { }

    public override void TakeDamage(int amount)
    {
        if (shield > 0)
        {
            int absorbed = Mathf.Min(amount, shield);
            shield -= absorbed;
            amount -= absorbed;
            Debug.Log($"Shield absorbs {absorbed} damage. Remaining shield: {shield}");
        }
        base.TakeDamage(amount);
    }
}

// Sử dụng Decorator trong game
public class DecoratorExample : MonoBehaviour
{
    void Start()
    {
        // Nhân vật cơ bản
        ICharacter basicCharacter = new BasicCharacter();

        // Thêm áo giáp
        ICharacter armoredCharacter = new ArmorDecorator(basicCharacter);

        // Thêm khiên
        ICharacter fullyEquippedCharacter = new ShieldDecorator(armoredCharacter);

        Debug.Log("Basic Character:");
        basicCharacter.TakeDamage(30); // Output: Took 30 damage. Remaining health: 70

        Debug.Log("\nArmored Character:");
        armoredCharacter.TakeDamage(30); // Output: Armor reduces damage by 10. Final damage: 20

        Debug.Log("\nFully Equipped Character:");
        fullyEquippedCharacter.TakeDamage(30); 
        // Output:
        // Shield absorbs 20 damage. Remaining shield: 0
        // Armor reduces damage by 10. Final damage: 0
    }
}
