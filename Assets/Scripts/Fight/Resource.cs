public class Resource {
	public string type;
	public int quantity;
	public bool Add(Resource additional) {
		if (additional.type == type) {
			quantity += additional.quantity;
			return true;
		}
		else return false;
	}
}
