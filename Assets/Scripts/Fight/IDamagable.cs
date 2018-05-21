using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable : IEntity {
	bool DealDamage(int damage);
}
