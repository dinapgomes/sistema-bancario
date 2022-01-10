using System;

class NConta {
  private Conta[] contas = new Conta[10];
  private int nc;

  public Conta[] Listar() {
    Conta[] c = new Conta[nc];
    Array.Copy(contas, c, nc);
    return c;
  }

  public Conta Listar(int id) {
    for (int i = 0; i < nc; i++)
      if (contas[i].getId() == id) return contas[i];
    return null;  
  }

  public void Inserir(Conta c) {
    if (nc == contas.Length) {
      Array.Resize(ref contas, 2 * contas.Length);
    }
    contas[nc] = c;
    nc++;
  } 

}