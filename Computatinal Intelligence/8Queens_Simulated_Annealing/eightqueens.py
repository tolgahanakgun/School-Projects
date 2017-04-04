import copy
import random
import math

from optparse import OptionParser
from timeit import default_timer as timer

class board:
    #Cagrildiginde rastgele 8'li bir satranc tahtasi olusturuyor
    def __init__(self, list=None):
        if list == None:
            self.board = [random.randint(0,7) for i in range(0,8)]
            
    #TODO
    def __str__(self):
        b = [[0 for i in range(0,8)] for j in range(0,8)]
        for i in range(0,8):
            b[self.board[i]][i] = 'X'
        mstr = ""
        for i in range(0,8):
            for j in range(0,8):
                mstr = mstr + str(b[i][j]) + " "
            mstr+='\n'
        return (mstr) #Var olan tahtanin resmini ciziyor
    
class queens():
    def __init__(self):
        #TODO
        self.restart=0
        self.totalnumsteps = 0
        
        #Simulated anneling icin sicaklik ve dengelyici degerleri
        self.current_system_temp = int(35)
        self.freezing_temp = 0
        self.current_stabilizer= float(35)
        self.stabilizing_factor = float(1.005)
        self.cooling_factor = float(0.05)
        
        
    
    def hill(self):
        find=0
        while find==0:
            self.mboard = board()
            self.cost = self.calc_cost(self.mboard)
            self.hill_solution()
            if(self.cost==0): # Eger hill solution'da 0 atak sayisi buluyorsa, tahtayi yazdirip donguden cikiyor    
                print "===================="
                print "Mukemmel Tahta"
                print "===================="
                print self.mboard
                find=1
            else: #Eger hill solution'da 0 atak sayisini bulamazsa LOCAL MAXIMUM'da takiliyor ve tahtaya restart atiyor
                self.restart+=1    
                print "===================="
                print "Tahta"," Burada tikandi",str(self.restart)," kez restart atti"
                print "===================="
        
        

    def hill_solution(self):
        while True: #Siradaki en dusuk komsuyu alip tahtayi yazdiriyor, en dusugu bulamazsa donguden cikiyor
            currViolations = self.cost
            self.getlowercostboard()
            if currViolations == self.cost:
                return
            self.totalnumsteps += 1 #Tabi her en dusuk atak sayisini buldugunda hareket sayisi artiyor
            print "Atak Sayisi", self.calc_cost(self.mboard)
            print self.mboard              
        return self.cost
    
    
        
    def calc_cost(self, tboard):
        #Tahtanin o anki dizlimine gore toplam atak sayisini hesapliyor ve geri donduruyor
        cost = 0
        for i in range(0,8):
            for j in range(i+1,8):
                #Yukari veya asagi ataklari buluyor
                if tboard.board[i] == tboard.board[j]:
                    cost += 1
                #Capraz ataklari buluyor
                offset = j - i
                if tboard.board[i] == tboard.board[j] - offset or tboard.board[i] == tboard.board[j] + offset:
                    cost +=1
        return cost
    
    def getlowercostboard(self):
        #Ilk en dusuk atak sayisi degerindeki tahta dizilimini buluyor ve sinifin tahtasi olarak atiyor
        lowcost = self.calc_cost(self.mboard)
        lowestavailable = self.mboard
        #Ilk vezirden baslayarak, her veziri sutunda hareket ettirip ilk en dusuk atak sayisini buluyor
        for q_col in range(0,8):
            for m_row in range(0,8):
                if self.mboard.board[q_col] != m_row:
                    tryboard = copy.deepcopy(self.mboard)
                    tryboard.board[q_col] = m_row
                    thiscost = self.calc_cost(tryboard)
                    if thiscost < lowcost:
                        lowcost = thiscost
                        lowestavailable = tryboard
        self.mboard = lowestavailable
        self.cost = lowcost
     
    def simulated_anneling(self):
        self.mboard = board()
        self.current_system_cost=self.calc_cost(self.mboard)
        #Sicaklik 0'a dusene kadar olasilik fonk. calistiriliyor. 0'a gelmede once en dusuk atak sayisini bulursa donguden cikiyor
        while self.current_system_temp > self.freezing_temp and self.current_system_cost!=0:#burda belki current_system_cost 0 ise yine de yinede girebilir            
            for i in range(int(self.current_stabilizer)): #Her sicaklik dusmesinde dengeleyici kadar dongu olasilik fon. calistiriyor                
                new_cost = self.s_generate_neighbor()
                cost_delta = new_cost - self.current_system_cost                
                
                if self.s_probability_function(self.current_system_temp, cost_delta):
                    #Olasilik fonk. true ise tahta yeni tahta olarak kabul ediliyor
                    self.mboard=copy.deepcopy(self.tryboard)
                    self.current_system_cost = new_cost
                    print "Atak Sayisi", self.current_system_cost
                    self.totalnumsteps+=1
                    #print self.mboard #Tahta yazdirilmak istendiginde bitis suresi yaklasik 7 ila 10 dakika arasi suruyor
                    print "Suan ki sicaklik degeri=",float(self.current_system_temp)
                    print "Suan ki dengeleyici sayisi=",self.current_stabilizer
                    print "##########################"
                    if new_cost==0: #Atak sayisi kontrolu                        
                        print self.mboard
                        return
                     
            self.current_system_temp = self.current_system_temp - self.cooling_factor
            self.current_stabilizer = self.current_stabilizer*self.stabilizing_factor#Her isi dusmesinde dengeleyici belli bir deger oraninde artiyor
        
        self.current_system_temp = self.freezing_temp
        
    def s_probability_function(self,temperature, delta): #Delta burda onceki ve sonraki atak sayisi farkidir  
        if delta<0:#Atak sayisi daha dusukse kabul ediliyor
            return True
        
        #Dusuk degilse assagidaki olasilik fonk. gore kabul ediliyor veya edilmiyor
        c=math.exp(-delta/temperature)
        r=random.random()
        
        if r<c:
            return True
        
        return False
    
    def s_generate_neighbor(self):
        #Rastgele bir vezir alinip rastgele bir hareket noktasine konup tahtanin atak sayisi donduruluyor
        repetitions = True #Iki veziri ayni noktaya koymamak icin bir tutarlilik degiskeni ile kontrol saglaniyor
        while repetitions == True:
            rand_queen=random.randint(0,7)
            rand_position=random.randint(0,7)
            if self.mboard.board[rand_queen]==rand_position:
                repetitions=True
            else:
                repetitions=False
            if repetitions==False:
                self.tryboard = copy.deepcopy(self.mboard)
                self.tryboard.board[rand_queen]=rand_position                      
        return self.calc_cost(self.tryboard)
    
        
    def printstats(self):
        #Tutalan degerler yazdiriliyor
        print "Toplam hareket sayisi=", self.totalnumsteps
        print "Toplam restart sayisi=", self.restart
        print "##########################"
    
if __name__ == "__main__":
    
    print'Hill Climbing calistiriliyor'
    table_h=[]
    for i in range(35):#Hill Solution 35 kere calistiriliyor      
        mboard = queens()
        start=timer()
        mboard.hill()
        end=timer()
        table_h+=[(mboard.totalnumsteps,mboard.restart,end-start)]
        mboard.printstats()
        
    average_step=0
    avarage_restart=0
    avarage_time=0
    print "Tablo:"
    print "Toplam hareket sayisi || ""Toplam restart sayisi || ""Bitis Suresi"
    for i in range(35):
        average_step+=table_h[i][0]
        avarage_restart+=table_h[i][1]
        avarage_time+=table_h[i][2]
        print ('{0:10d} {1:25d} {2:23f}'.format(table_h[i][0],table_h[i][1],table_h[i][2]))
    print "\n"
    print "Ortalama hareket sayisi || ""Ortalama restart sayisi || ""Ortalama Bitis Suresi"
    print ('{0:10d} {1:25d} {2:31f}'.format(average_step/35,avarage_restart/35,avarage_time/35))
    print "\n"
    print'Simulated Anneling calistiriliyor' 
    mboard=queens()
    start=timer()
    mboard.simulated_anneling()
    end=timer()
    print'Sonuclar:'
    print'Hill Climbing:'
    
    print "Tablo:"
    print "Toplam hareket sayisi || ""Toplam restart sayisi || ""Bitis Suresi(saniye)"
    for i in range(35):
        average_step+=table_h[i][0]
        avarage_restart+=table_h[i][1]
        avarage_time+=table_h[i][2]
        print ('{0:10d} {1:25d} {2:27f}'.format(table_h[i][0],table_h[i][1],table_h[i][2]))
    print "\n"
    print "Ortalama hareket sayisi || ""Ortalama restart sayisi || ""Ortalama Bitis Suresi(saniye)"
    print ('{0:10d} {1:25d} {2:36f}'.format(average_step/35,avarage_restart/35,avarage_time/35))
    
    print "Simulated Anneling:"
    print "Bitis suresi={0:5f}".format(end-start)
    print "Toplam hareket sayisi", mboard.totalnumsteps