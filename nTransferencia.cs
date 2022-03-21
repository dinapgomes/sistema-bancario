using System;
using System.Collections.Generic;
using System.Linq;

class NTransferencia {
  private Transferencia[] transferencias = new Transferencia[10];
  private int nt;

  public void Abrir() {
    Arquivo<Transferencia[]> f = new Arquivo<Transferencia[]>();
    transferencias = f.Abrir("./transferencias.xml");
    nt = transferencias.Length;
  }

  public void Salvar() {
    Arquivo<Transferencia[]> f = new Arquivo<Transferencia[]>();
    f.Salvar("./transferencias.xml", Listar());
  }
  
  public Transferencia[] Listar() {
    return transferencias.Take(nt).OrderBy(obj => obj.Valor).ToArray();
  }

  public Transferencia Listar(int id) {
    return transferencias.FirstOrDefault(obj => obj.Id == id);
  }

  public Transferencia[] ListarPorConta(int ct) {
    return transferencias.Where(t => t.ContaOrigem == ct).ToArray();
  }

  public void Inserir(Transferencia t) {
    if (nt == transferencias.Length) {
      Array.Resize(ref transferencias, 2 * transferencias.Length);
    }
    transferencias[nt] = t;
    nt++;
  } 

  public void Atualizar(Transferencia t) {
    Transferencia t_atual = Listar(t.Id);
    if (t_atual == null) return;
    t_atual.Data = t.Data;
    t_atual.Valor = t.Valor;
    t_atual.ContaOrigem = t.ContaOrigem;
    t_atual.ContaDestino = t.ContaDestino;
  }

  private int Indice(Transferencia t) {
    for (int i = 0; i < nt; i++)
      if (transferencias[i] == t) return i;
    return -1;      
  }
  
  public void Excluir(Transferencia t) {
    int n = Indice(t);
    if (n == -1) return;
    for (int i = n; i < nt - 1; i++)
      transferencias[i] = transferencias[i + 1];
    nt--;
  }
}