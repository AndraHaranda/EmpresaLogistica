using System;

namespace ProvaAndra
{

	public class PILHA
	{
		public int topo = 0;
		public int[] item = new int[DefineConstants.tamPilha];
	}

	public static class GlobalMembers
	{
		public static bool pilhaVazia(PILHA p)
		{
			if (p.topo == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool pilhaCheia(PILHA p)
		{
			int tam = p.item.Length;

			if (p.topo < tam)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static void empilha(PILHA p, int x)
		{
			p.item[p.topo++] = x;
		}

		public static int desempilha(PILHA p)
		{
			return p.item[--p.topo];
		}

		public static int valorTopo(PILHA p)
		{
			return p.item[p.topo - 1];
		}

		public static void mostraPilha(PILHA p)
		{
			Console.Write("Valores da pilha: ");
			if (p.topo > 0)
			{
				for (int i = 0; i < p.topo; i++)
				{
					Console.Write(p.item[i]);
					Console.Write(" ");
				}
			}
			else
			{
				Console.Write("pilha vazia");
			}
			Console.Write("\n");
		}

		public static void mostraPorto(PILHA[] vet)
		{
			for (int i = 0; i < DefineConstants.tamPorto; i++)
			{
				Console.Write("Porto ");
				Console.Write(i + 1);
				Console.Write(" -> ");
				mostraPilha(vet[i]);
			}
		}
		public static int pilhaMaisVazia(PILHA[] vet)
		{

			int menor = vet[0].topo;
			int posicao = 0;
			for (int i = 1; i < DefineConstants.tamPorto; i++)
			{
				if (vet[i].topo < menor)
				{
					menor = vet[i].topo;
					posicao = i;
				}
			}

			return posicao;
		}

		public static void mostraOpcoes()
		{
			Console.Write("Opcoes disponiveis: ");
			Console.Write("\n");
			Console.Write("0: sair");
			Console.Write("\n");
			Console.Write("1: adicionar container");
			Console.Write("\n");
			Console.Write("2: remover   container");
			Console.Write("\n");
			Console.Write("Digite sua opcao: ");
		}

		public static int codigoExiste(PILHA[] vet, int cod)
		{
			for (int i = 0; i < DefineConstants.tamPorto; i++)
			{
				for (int j = 0; j < vet[i].topo; j++)
				{
					if (vet[i].item[j] == cod)
					{
						return i;
					}
				}
			}
			return -1;
		}

		internal static void Main()
		{
			PILHA[] local = Arrays.InitializeWithDefaultInstances<PILHA>(DefineConstants.tamPorto);
			int opcao;
			int codigo;

			while (true)
			{
				mostraOpcoes();
				opcao = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				if (opcao == 0)
				{
					break;
				}

				Console.Write("Informe o codigo do container: ");
				codigo = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

				if (opcao == 1)
				{
					if (codigoExiste(local, codigo) != -1)
					{
						Console.Write("Codigo invalido");
						Console.Write("\n");
					}
					else
					{
						int posicaoPorto = pilhaMaisVazia(local);
						if (pilhaCheia(local[posicaoPorto]))
						{
							Console.Write("Impossivel empilhar!");
							Console.Write("\n");
						}
						else
						{
							empilha(local[posicaoPorto], codigo);
						}
					}
				}
				else
				{
					int posicaoPorto = codigoExiste(local, codigo);
					if (posicaoPorto == -1)
					{
						Console.Write("Codigo invalido!");
						Console.Write("\n");
					}
					else
					{
						if (valorTopo(local[posicaoPorto]) == codigo)
						{
							desempilha(local[posicaoPorto]);
						}
						else
						{
							Console.Write("Impossivel desempilhar!");
							Console.Write("\n");
						}
					}
				}

				mostraPorto(local);
				Console.Write("\n");
			}

		}
	}
}
