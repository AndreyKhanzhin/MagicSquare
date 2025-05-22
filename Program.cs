Console.WriteLine("Введите размерность матрицы от 1 до 1000");

int n;
while (!(int.TryParse(Console.ReadLine(), out n)))
{
    Console.WriteLine("Вы ввели не те данные.");
}

int[,] ms = new int[n, n];

if (n == 1)
{
    Console.WriteLine("1");
}
else
{
    if (n == 2)
    {
        Console.WriteLine("Магический квадрат невозможен");
    }
    else
    {
        if (n % 2 == 1)
        {
            int i = 0, j = n / 2;
            for (int num = 1; num <= n * n; num++)
            {
                ms[i, j] = num;
                int ni = (i + n - 1) % n;
                int nj = (j + 1) % n;
                if (ms[ni, nj] != 0)
                {
                    i = (i + 1) % n;
                }
                else
                {
                    i = ni;
                    j = nj;
                }
            }
        }
        else if (n % 4 == 0)
        {
            int num = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ms[i, j] = num++;
                }
            }

            int lim = n * n + 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 4 == j % 4 || (i % 4) + (j % 4) == 3)
                    {
                        ms[i, j] = lim - ms[i, j];
                    }
                }
            }
        }
        else
        {
            int m = n / 2;
            int[,] sub = new int[m, m];

            int i = 0, j = m / 2;
            for (int num = 1; num <= m * m; num++)
            {
                sub[i, j] = num;
                int ni = (i + m - 1) % m;
                int nj = (j + 1) % m;
                if (sub[ni, nj] != 0)
                {
                    i = (i + 1) % m;
                }
                else
                {
                    i = ni;
                    j = nj;
                }
            }

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    int val = sub[r, c];
                    ms[r, c] = val;
                    ms[r, c + m] = val + 2 * m * m;
                    ms[r + m, c] = val + 3 * m * m;
                    ms[r + m, c + m] = val + m * m;
                }
            }

            int k = (n - 2) / 4;
            for (int i1 = 0; i1 < m; i1++)
            {
                for (int j1 = 0; j1 < k; j1++)
                {
                    int tmp = ms[i1, j1];
                    ms[i1, j1] = ms[i1 + m, j1];
                    ms[i1 + m, j1] = tmp;
                }

                for (int j1 = n - k + 1; j1 < n; j1++)
                {
                    int tmp = ms[i1, j1];
                    ms[i1, j1] = ms[i1 + m, j1];
                    ms[i1 + m, j1] = tmp;
                }
            }

            int middle = k;
            int tmp2 = ms[k, middle];
            ms[k, middle] = ms[k + m, middle];
            ms[k + m, middle] = tmp2;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("|" + ms[i, j] + "|");
            }
            Console.WriteLine();
        }
    }
}