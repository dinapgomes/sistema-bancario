using System;
using System.Collections.Generic;

class Program {
  public static NConta nconta = new NConta();
  public static NTransferencia ntransferencia = new NTransferencia();
  public static NSaque nsaque = new NSaque();
  public static NEmprestimo nemprestimo  = new NEmprestimo();

  public static void Main() {
    Conta c1 = new Conta(1, 10.0, 123);
    Conta c2 = new Conta(2, 5.3, 321);
    nconta.Inserir(c2);
    nconta.Inserir(c1);

    int op = 0;
    Console.WriteLine ("----- Sistema Bancário ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : transferenciaListar(); break;
          case 2 : transferenciaCriar(); break;
          case 3 : transferenciaAtualizar(); break;
          case 4 : transferenciaExcluir(); break;
          case 5 : contaListar(); break;
          case 6 : contaCriar(); break;
          case 7: contaAtualizar(); break;
          case 8: contaExcluir(); break;
          case 9 : saqueListar(); break;
          case 10 : saqueCriar(); break;
          case 11: saqueAtualizar(); break;
          case 12: saqueExcluir(); break;
          case 13 : emprestimoListar(); break;
          case 14 : emprestimoCriar(); break;
          case 15 : emprestimoAtualizar(); break;
          case 16 : emprestimoExcluir(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("FIM!");    
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("--------Tranferência----------");
    Console.WriteLine("1 - Listar");
    Console.WriteLine("2 - criar");
    Console.WriteLine("3 - atualizar");
    Console.WriteLine("4 - excluir");
    Console.WriteLine("----------Conta---------------");
    Console.WriteLine("5 - Listar");
    Console.WriteLine("6 - criar");
    Console.WriteLine("7 - atualizar");
    Console.WriteLine("8 - excluir");
    Console.WriteLine("-----------Saque--------------");
    Console.WriteLine("9 - Listar");
    Console.WriteLine("10 - criar");
    Console.WriteLine("11 - atualizar");
    Console.WriteLine("12 - excluir");
    Console.WriteLine("----------Empréstimo----------");
    Console.WriteLine("13 - Listar");
    Console.WriteLine("14 - criar");
    Console.WriteLine("15 - atualizar");
    Console.WriteLine("16 - excluir");
    Console.WriteLine("------------------------------");
    Console.WriteLine("0 - Fim");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static void transferenciaListar() {
    Console.WriteLine("----- Lista de Tranfêrencias -----");
    List<Transferencia> ts = ntransferencia.Listar();
    if (ts.Count == 0) {
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