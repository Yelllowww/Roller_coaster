# Relatório - Simulação de Montanha Russa

## 1. Definição do problema

O Problema da Montanha Russa consiste na utilização de subprocessos para exercer
paralelismo, de forma que simule um passeio real de montanha russa, em que passageiros
chegam de forma aleatória e o passeio ocorre de um em um carrinho. E concorrência no
acesso a recursos compartilhados, sendo esses os passageiros e os carrinhos.

## 2. Algoritmos propostos

O sistema foi implementado em C# utilizando programação assíncrona e estruturas de dados
concorrentes. Os principais algoritmos e estruturas são:

- Criação de carrinhos: O método GerarCarrinhos cria um objeto carrinho com id único e
enfileira ele na fila de carrinho, e também os adiciona em uma outra fila para estatísticas.
- Controle de Concorrência: Uso de _SemaphoreSlim_ para sincronizar o embarque e
desembarque dos passageiros.
- Criação de Passageiros: Cada passageiro é representado por uma _Task_ que aguarda seu
embarque, simulando processos independentes. O método _GerarPassageiros_ cria os
passageiros com um id único e de forma aleatória, conforme _ids.RemoveAt(index)_ e os
intervalos de chegada.
- Embarque: O método _EmbarcarPassageiros_ retira passageiros da fila até preencher a
capacidade do carrinho, chamando o método _Embarcar,_ que os adiciona na fila do carrinho. E
nisso, marca o tempo de espera de cada passageiro e simula o tempo de embarque
- Passeio: O método _Passeio_ espera pelo método de embarque com o uso do semáforo, com
um carrinho por vez, simula o passeio e contabiliza o tempo de passeio pelo método
AdicionarTempo, que soma cada tempo de passeio na variável tempoDeUso. Em seguida
desembarca os passageiros um por vez, contabilizando o tempo de desembarque e os
passageiros que foram atendidos. E ao final, retorna o carrinho para a fila e libera o semáforo.
- Estatísticas: Ao final da simulação, quando todos os passageiros foram atendidos, o método
_Estatisticas_ procura e calcula o tempo mínimo, máximo e médio de espera dos passageiros e a
eficiência dos carrinhos; com o tempo total da simulação.
- Reinício: O método _Retry_ zera todas as variáveis e limpa as filas para começar a simulação do
zero.

## 3. Manual de utilização

#### 1. Execução:

Compile e execute o programa em um ambiente .NET compatível.

#### 2. Configuração:


Ao iniciar, o programa solicita ao usuário que escolha entre:

- Inserir valores personalizados (opção 1)
- Usar valores padrão (opção 2)
- Sair (opção 3)

#### 3. Parâmetros configuráveis:

- Número de carrinhos
- Número de passageiros
- Capacidade dos carrinhos
- Tempo de passeio (em segundos)
- Tempo de embarque/desembarque (em segundos)
- Intervalo mínimo e máximo de chegada dos passageiros (em segundos)

#### 4. Execução da simulação:

- Os carrinhos são criados e enfileirados.
- Carrinhos embarcam passageiros conforme vão chegando.
- Carrinho sai para o passeio quando está cheio.
- Carrinho desembarca os passageiros e eles são atendidos.
- Ao final, são exibidas as estatísticas da simulação.
- O usuário pode optar por sair ou reiniciar a simulação.

## 4. Resultados e análises

#### Análises

Influência da capacidade de cada carrinho e a quantidade de carrinhos nos tempos de espera,
assim como a eficiência de cada carrinho a partir de 3 casos teste.

**Implementação de testes em 3 casos:**

**N** : Número total de passageiros

1° caso: 6 5 2° caso: 6 5 3° caso: 1000

**M** : Número total de carrinhos

1° caso: 1 2° caso: 2 3° caso: 1000

**C** : Capacidade de cada carrinho

1° caso: 5 2° caso: 5 3° caso: 10

**Tm** : Tempo de passeio

1° caso: 60 segundos 2° caso: 60 segundos 3° caso: 60 segundos


**Te** : Tempo de embarque/desembarque

1° caso: 25 2° caso: 2 5 3° caso: 25

**Tp** : Intervalo de chegada dos passageiros

1° caso: 10 a 20 2° caso: 10 a 20 3° caso: 10 a 20

#### Resultados

##### CASO 1:

Tempo mínimo de espera na fila: 41,63 segundos

Tempo máximo de espera na fila: 3772,47 segundos

Tempo médio de espera na fila: 1908,95 segundos

Carro 0 - Eficiência: 16,54%

CASO 2:

Tempo mínimo de espera na fila: 46,79 segundos

Tempo máximo de espera na fila: 583,76 segundos

Tempo médio de espera na fila: 328,08 segundos

Carro 0 - Eficiência: 15,89%

Carro 1 - Eficiência: 13,60%

CASO 3:

Tempo mínimo de espera na fila: 41,32 segundos

Tempo máximo de espera na fila: 16402,28 segundos

Tempo médio de espera na fila: 8225,70 segundos

Carro 0 - Eficiência: 0,20%

Carro 1 - Eficiência: 0,19%

Carro 2 - Eficiência: 0,19%

Carro 3 - Eficiência: 0,20%

Carro 4 - Eficiência: 0,19%

Carro 5 - Eficiência: 0,20%

Carro 6 - Eficiência: 0,19%

Carro 7 - Eficiência: 0,19%

Carro 8 - Eficiência: 0,19%

Carro 9 - Eficiência: 0,19%

Carro 10 - Eficiência: 0,19%


Carro 11 - Eficiência: 0,19%

Carro 12 - Eficiência: 0,19%

Carro 13 - Eficiência: 0,19%

Carro 14 - Eficiência: 0,21%

Carro 15 - Eficiência: 0,18%

Carro 16 - Eficiência: 0,20%

Carro 17 - Eficiência: 0,20%

Carro 18 - Eficiência: 0,20%

Carro 19 - Eficiência: 0,18%

Carro 20 - Eficiência: 0,19%

Carro 21 - Eficiência: 0,20%

Carro 22 - Eficiência: 0,20%

Carro 23 - Eficiência: 0,20%

Carro 24 - Eficiência: 0,20%

Carro 25 - Eficiência: 0,19%

Carro 26 - Eficiência: 0,17%

Carro 27 - Eficiência: 0,19%

Carro 28 - Eficiência: 0,20%

Carro 29 - Eficiência: 0,20%

Carro 30 - Eficiência: 0,19%

Carro 31 - Eficiência: 0,20%

Carro 32 - Eficiência: 0,19%

Carro 33 - Eficiência: 0,20%

Carro 34 - Eficiência: 0,20%

Carro 35 - Eficiência: 0,20%

Carro 36 - Eficiência: 0,20%

Carro 37 - Eficiência: 0,20%

Carro 38 - Eficiência: 0,20%

Carro 39 - Eficiência: 0,20%

Carro 40 - Eficiência: 0,20%

Carro 41 - Eficiência: 0,20%


Carro 42 - Eficiência: 0,20%

Carro 43 - Eficiência: 0,19%

Carro 44 - Eficiência: 0,20%

Carro 45 - Eficiência: 0,20%

Carro 46 - Eficiência: 0,20%

Carro 47 - Eficiência: 0,20%

Carro 48 - Eficiência: 0,20%

Carro 49 - Eficiência: 0,20%

Carro 50 - Eficiência: 0,20%

Carro 51 - Eficiência: 0,20%

Carro 52 - Eficiência: 0,19%

Carro 53 - Eficiência: 0,20%

Carro 54 - Eficiência: 0,19%

Carro 55 - Eficiência: 0,20%

Carro 56 - Eficiência: 0,20%

Carro 57 - Eficiência: 0,20%

Carro 58 - Eficiência: 0,20%

Carro 59 - Eficiência: 0,20%

Carro 60 - Eficiência: 0,20%

Carro 61 - Eficiência: 0,20%

Carro 62 - Eficiência: 0,20%

Carro 63 - Eficiência: 0,20%

Carro 64 - Eficiência: 0,19%

Carro 65 - Eficiência: 0,20%

Carro 66 - Eficiência: 0,20%

Carro 67 - Eficiência: 0,19%

Carro 68 - Eficiência: 0,19%

Carro 69 - Eficiência: 0,20%

Carro 70 - Eficiência: 0,20%

Carro 71 - Eficiência: 0,20%

Carro 72 - Eficiência: 0,20%


Carro 73 - Eficiência: 0,20%

Carro 74 - Eficiência: 0,19%

Carro 75 - Eficiência: 0,20%

Carro 76 - Eficiência: 0,20%

Carro 77 - Eficiência: 0,20%

Carro 78 - Eficiência: 0,17%

Carro 79 - Eficiência: 0,19%

Carro 80 - Eficiência: 0,20%

Carro 81 - Eficiência: 0,20%

Carro 82 - Eficiência: 0,20%

Carro 83 - Eficiência: 0,21%

Carro 84 - Eficiência: 0,19%

Carro 85 - Eficiência: 0,19%

Carro 86 - Eficiência: 0,20%

Carro 87 - Eficiência: 0,18%

Carro 88 - Eficiência: 0,20%

Carro 89 - Eficiência: 0,20%

Carro 90 - Eficiência: 0,20%

Carro 91 - Eficiência: 0,20%

Carro 92 - Eficiência: 0,20%

Carro 93 - Eficiência: 0,20%

Carro 94 - Eficiência: 0,22%

Carro 95 - Eficiência: 0,20%

Carro 96 - Eficiência: 0,19%

Carro 97 - Eficiência: 0,20%

Carro 98 - Eficiência: 0,20%

Carro 99 - Eficiência: 0,20%

... – Eficiência: 0,00%

Carro 999 – Eficiência 0,00%


#### Conclusões:

- A partir desses dados, é visto que no caso 1 se tem um tempo médio de espera bem

#### maior, devido a utilização de somente um carrinho para o embarque dos passageiros,

#### comparado com o caso 2, onde se tem 2 carrinhos.

- Também se observa que no caso 2, a eficiência de cada carrinho decai, comparado ao

#### caso 1, devido em alguns momentos ter mais carrinhos do que passageiros na fila.

- Com o aumento do número de carrinhos, a vazão do sistema aumenta, porém em

#### consequência aumenta a ociosidade dos carrinhos.

- Como há uma maior capacidade no caso 3, há uma espera maior até que o carrinho

#### saia para o passeio, consequentemente aumentando o tempo de espera dos

#### passageiros e a ociosidade dos outros carrinhos

- Também no caso 3, a eficiência de cada carrinho é muito baixa, pois além da

#### ociosidade pela maior capacidade, há muito mais carrinhos do que o necessário,

#### ficando a maioria sem ser utilizados

### Com isso, o projeto atinge o objetivo de simular uma montanha russa

### concorrente, fornecendo dados robustos e relevantes para análise do

### desempenho e permitindo múltiplas execuções sem interferência entre

### rodadas. O uso de programação assíncrona e estruturas thread-safe

### garante funcionamento preemptivo e sem interrupções, como Deadlock e

### Starvation.

#### - Eduardo do Vale Giannetti, RA 22310624
