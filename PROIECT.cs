using System;

public class Produs
{
	public int Id { get; set; }
	public string Nume { get; set; }
	public decimal Pret { get; set; }

	public Produs(int id, string nume, decimal pret)
	{
		Id = id;
		Nume = nume;
		Pret = pret;
	}
}

public class ProduseLista
{
	private List<Produs> produse = new List<Produs>();
	public ProduseLista()
	{
		produse.Add(new Produs(1, "Apple", 0.50m));
        produse.Add(new Produs(1, "Apple", 0.50m));
        produse.Add(new Produs(1, "Apple", 0.50m));
    }
	public void AddProdus(Produs produs)
	{
		produs.Add(produs);
	}
	public void StergeProdus(Produs produs)
	{
		produs.Sterge(produs);
	}
	public List<Produs> GetProduse()
	{
		return produse;
	}
}
