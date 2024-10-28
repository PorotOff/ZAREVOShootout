public interface IMovable
{
	public float MovementForce { get; }
	public float MovementForceModification { get; }

	public void Move(float movementForce);
	public void ModificateSpeed(float movementForceModification);
}