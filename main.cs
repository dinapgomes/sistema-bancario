using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  public static NConta nconta = new NConta();
  public static NTransferencia ntransferencia = new NTransferencia();
  public static NSaque nsaque = new NSaque();
  public static NEmprestimo nemprestimo  = new NEmprestimo();

  public static void Main() {
    try {
      nconta.Abrir();
      nemprestimo.Abrir();
      ntransferencia.Abrir();
      nsaque.Abrir();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }

    int op = 0;
    Console.WriteLine ("----- Sistema Bancário ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : transferenciaListar(); break;
          case 2 : transferenciaListarPorConta(); break;
          case 3 : transferenciaCriar(); break;
          case 4 : transferenciaAtualizar(); break;
          case 5 : transferenciaExcluir(); break;
          case 6 : contaListar(); break;
          case 7 : contaCriar(); break;
          case 8: contaAtualizar(); break;
          case 9: contaExcluir(); break;
          case 10 : saqueListar(); break;
          case 11 : saqueCriar(); break;
          case 12: saqueAtualizar(); break;
          case 13: saqueExcluir(); break;
          case 14 : emprestimoListar(); break;
          case 15 : emprestimoCriar(); break;
          case 16 : emprestimoAtualizar(); break;
          case 17 : emprestimoExcluir(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    try {
      nconta.Salvar();
      nemprestimo.Salvar();
      ntransferencia.Salvar();
      nsaque.Salvar();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }
    Console.WriteLine ("FIM!");    
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("--------Tranferência----------");
    Console.WriteLine("1 - Listar");
    Console.WriteLine("2 - Listar por conta");
    Console.WriteLine("3 - criar");
    Console.WriteLine("4 - atualizar");
    Console.WriteLine("5 - excluir");
    Console.WriteLine("----------Conta---------------");
    Console.WriteLine("6 - Listar");
    Console.WriteLine("7 - criar");
    Console.WriteLine("8 - atualizar");
    Console.WriteLine("9 - excluir");
    Console.WriteLine("-----------Saque--------------");
    Console.WriteLine("10 - Listar");
    Console.WriteLine("11 - criar");
    Console.WriteLine("12 - atualizar");
    Console.WriteLine("13 - excluir");
    Console.WriteLine("----------Empréstimo----------");
    Console.WriteLine("14 - Listar");
    Console.WriteLine("15 - criar");
    Console.WriteLine("16 - atualizar");
    Console.WriteLine("17 - excluir");
    Console.WriteLine("------------------------------");
    Console.WriteLine("0 - Fim");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static void transferenciaListar() {
    Console.WriteLine("----- Lista de Tranfêrencias -----");
    Transferencia[] ts = ntransferencia.Listar();
    if (ts.Length == 0) {
      Console.WriteLine("Nenhuma tranfêrencia cadastrada");
      return;
    }
    foreach(Transferencia t in ts) Console.WriteLine(t);
    Console.WriteLine(); 

    var t1 = ts.Select(t => new {
      data = t.Data,
      Valor = t.Valor
    });

    var t2 = t1.GroupBy(item => item.data,
      (key, items) => new {
        data = key,
        Total = items.Sum(item => item.Valor) 
    });

    foreach(var item in t2) Console.WriteLine(item);
    Console.WriteLine();
  }

  public static void transferenciaListarPorConta() {
    Console.WriteLine("-- Lista de Tranfêrencias por conta --");
    Console.Write("Informe a conta de Origem das tranfêrencias: ");
    int idContaOrigem = int.Parse(Console.ReadLine());
    Transferencia[] ts = ntransferencia.ListarPorConta(idContaOrigem);
    if (ts.Length == 0) {
      Console.WriteLine("Nenhuma tranfêrencia cadastrada");
      return;
    }
    foreach(Transferencia t in ts) Console.WriteLine(t);
    Console.WriteLine(); 
  }

  public static void transferenciaCriar() {
    Console.WriteLine("----- criação de Tranfêrencias -----");
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para a tranfêrencia: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para a tranfêrencia: ");
    int idContaOrigem = int.Parse(Console.ReadLine());
    Console.Write("Informe a conta de destino para a tranfêrencia: ");
    int idContaDestino = int.Parse(Console.ReadLine());

    List<Conta> contas = nconta.Listar();
    Conta contaOrigem = nconta.Listar(idContaOrigem);
    Conta contaDestino  = nconta.Listar(idContaDestino);

    Transferencia t = new Transferencia(1, data, valor, idContaOrigem, idContaDestino);
    ntransferencia.Inserir(t);
    
    contaOrigem.sacar(valor);
    contaDestino.depositar(valor);

    nconta.Atualizar(contaOrigem);
    nconta.Atualizar(contaDestino);
  }

  public static void transferenciaAtualizar(){
     Console.WriteLine("----- Atualização de Transfêrencias -----");
    Console.Write("Informe um id para a tranfêrencia: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para a tranfêrencia: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para a tranfêrencia: ");
    int idContaOrigem = int.Parse(Console.ReadLine());
    Console.Write("Informe a conta de destino para a tranfêrencia: ");
    int idContaDestino = int.Parse(Console.ReadLine());

    Transferencia t = new Transferencia(id, data, valor, idContaOrigem, idContaDestino);
    ntransferencia.Atualizar(t);
  }

  public static void transferenciaExcluir(){
    Console.WriteLine("----- Exclusão de Tranferência -----");
    Console.Write("Informe o id da tranfêrencia a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    Transferencia t = ntransferencia.Listar(id);
    ntransferencia.Excluir(t);
  }

  public static void contaListar() {
    Console.WriteLine("----- Lista de Contas -----");
    List<Conta> cs = nconta.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhuma conta cadastrada");
      return;
    }
    foreach(Conta c in cs) Console.WriteLine(c);
    Console.WriteLine(); 
  }

  public static void contaCriar() {
    Console.WriteLine("----- Inserção de Conta -----");
    Console.Write("Informe o número da conta: ");
    int conta = int.Parse(Console.ReadLine());
    
    Conta c = new Conta(0, 0, conta);
    nconta.Inserir(c);
  }

  public static void contaAtualizar() {
    Console.WriteLine("----- atualização de Conta -----");
    Console.Write("Informe id da conta: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o saldo da conta: ");
    double saldo = double.Parse(Console.ReadLine());
    Console.Write("Informe o número da conta: ");
    int conta = int.Parse(Console.ReadLine());
    
    Conta c = new Conta(id, saldo, conta);
    nconta.Atualizar(c);
  }

  public static void contaExcluir(){
    Console.WriteLine("----- Exclusão de conta -----");
    Console.Write("Informe o id da conta a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    Conta c = nconta.Listar(id);
    nconta.Excluir(c);
  }

  public static void saqueCriar() {
    Console.WriteLine("----- criação de Saques -----");
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para o saque: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para o saque: ");
    int idContaOrigem = int.Parse(Console.ReadLine());

    Conta contaOrigem = nconta.Listar(idContaOrigem);
    contaOrigem.sacar(valor);
    nconta.Atualizar(contaOrigem);

    Saque s = new Saque(0, data, valor, idContaOrigem);
    nsaque.Inserir(s);
  }

  public static void saqueListar() {
    Console.WriteLine("----- Lista de Saques -----");
    List<Saque> ss = nsaque.Listar();
    if (ss.Count == 0) {
      Console.WriteLine("Nenhum saque cadastrado");
      return;
    }
    foreach(Saque s in ss) Console.WriteLine(s);
    Console.WriteLine(); 
  
  }

  public static void saqueAtualizar() {
    Console.WriteLine("----- Atualização de saques -----");
    Console.Write("Informe id para o saque: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para o saque: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para o saque: ");
    int idContaOrigem = int.Parse(Console.ReadLine());

    Saque s = new Saque(id, data, valor, idContaOrigem);
    nsaque.Atualizar(s);
  }

  public static void saqueExcluir() {
    Console.WriteLine("----- Exclusão de saque -----");
    Console.Write("Informe o id de saque a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    Saque s = nsaque.Listar(id);
    nsaque.Excluir(s);
  }

  public static void emprestimoCriar() {
    Console.WriteLine("----- criação de Empréstimo -----");
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para do empréstimo: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para o empréstimo: ");
    int idContaOrigem = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade de parcelas: ");
    int qtdParcelas = int.Parse(Console.ReadLine());
    
    Emprestimo e = new Emprestimo( 0, data, valor,         idContaOrigem, qtdParcelas);
    nemprestimo.Inserir(e);

    Conta contaOrigem = nconta.Listar(idContaOrigem);
    contaOrigem.depositar(valor);
    nconta.Atualizar(contaOrigem);
  }

  public static void emprestimoListar() {
    Console.WriteLine("----- Lista de Emprestimo -----");
    List<Emprestimo> es = nemprestimo.Listar();
    if (es.Count == 0) {
      Console.WriteLine("Nenhum emprestimo cadastrado");
      return;
    }
    foreach(Emprestimo e in es) Console.WriteLine(e);
    Console.WriteLine(); 
  
  }

  public static void emprestimoAtualizar() {
    Console.WriteLine("----- Atualização de emprestimo -----");
    Console.Write("Informe id para o emprestimo: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a data: ");
    string data = Console.ReadLine();
    Console.Write("Informe o valor para o emprestimo: ");
    double valor= double.Parse(Console.ReadLine());
    Console.Write("Informe a conta de Origem para o emprestimo: ");
    int idContaOrigem = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade de parcelas: ");
    int qtdParcelas = int.Parse(Console.ReadLine());

    Emprestimo e = new Emprestimo(id, data, valor,         idContaOrigem, qtdParcelas);
    nemprestimo.Atualizar(e);
  }

  public static void emprestimoExcluir() {
    Console.WriteLine("----- Exclusão de emprestimo -----");
    Console.Write("Informe o id do emprestimo a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    Emprestimo e = nemprestimo.Listar(id);
    nemprestimo.Excluir(e);
  }
}