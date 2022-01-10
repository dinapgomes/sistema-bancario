using System;

class NTransferencia {
  private Transferencia[] transferencias = new Transferencia[10];
  private int nt;

  public Transferencia[] Listar() {
    Transferencia[] t = new Transferencia[nt];
    Array.Copy(transferencias, t, nt);
    return t;
  }

  public Transferencia Listar(int id) {
    for (int i = 0; i < nt; i++)
      if (transferencias[i].getId() == id) return transferencias[i];
    return null;  
  }

  public void Inserir(Transferencia t) {
    if (nt == transferencias.Length) {
      Array.Resize(ref transferencias, 2 * transferencias.Length);
    }
    transferencias[nt] = t;
    nt++;
  } 

}